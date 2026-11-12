using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlanList
    {
        List<FlightPlan> vector = new List<FlightPlan>(); //Aixo es lo del BLO3, llista indef

        public int AddFlightPlan(FlightPlan p) //existeix el .add de normal, pq creem List<flightplan> BLO3
        {
            vector.Add(p);
            return 0;
        }
        public FlightPlan GetFlightPlan(int i)
        {
            if (i < 0 || i >= vector.Count) //.count es BLO3
            {
                return null;
            }
            else
            {
                return vector[i];
            }
        }
        public int GetListSize()
        {
            return vector.Count;
        }

        public void RestartList()
        {
            for (int i = 0; i < vector.Count; i++)
            {
                vector[i].Restart();
            }
        }

        public void Mover(double tiempo)
        {
            int i = 0;

            while (i < vector.Count)
            {
                vector[i].Mover(tiempo);
                i++;
            }
        }
        public void EscribeConsola()
        {
            int i = 0;

            while (i < vector.Count)
            {
                vector[i].EscribeConsola();
                i++;
            }
        }


        public bool HayConflicto(double distanciaSeguridad) //comprovem conflicte entre tots els vols de la llista
        {
            int i = 0;

            while (i < vector.Count)
            {
                int j = i + 1;

                while (j < vector.Count)
                {
                    if (vector[i].Conflicto(vector[j], distanciaSeguridad))
                        return true;

                    j++;
                }

                i++;
            }

            return false;
        }

        //Volem trobar la velocitat pq no entrin en conflicte, modifico sempre flightplan b.
        private double VelocidadSegura(FlightPlan FA, FlightPlan FB, double distanciaSeguridad)
        {
            Position PosA = FA.GetCurrentPosition();
            Position PosB = FB.GetCurrentPosition();
            //distancia que li queda al final
            double distA= PosA.Distancia(FA.GetFinalPosition());
            double distB = PosB.Distancia(FB.GetFinalPosition());

            double velA = FA.GetVelocidad()/60;
            double velB = FB.GetVelocidad()/60;

            //si algun vol ha arribat, no cal calcular res
            if (distA == 0 || distB == 0 || velA == 0 || velB == 0)
            {
                return -1;
            }

            double tempsA= distA / velA;
            double tempsB = distB / velB;

            // lo que li falta a cada vol per arribar al final
            double dAx=FA.GetFinalPosition().GetX() - PosA.GetX();
            double dAy = FA.GetFinalPosition().GetY() - PosA.GetY();
            double dBx = FB.GetFinalPosition().GetX() - PosB.GetX();
            double dBy = FB.GetFinalPosition().GetY() - PosB.GetY();

            //temps on estan mes a prop
            double tmin=FA.TiempoMinimo(PosA.GetX()-PosB.GetX(), PosA.GetY() - PosB.GetY(), dAx/tempsA-dBx/tempsB, dAy/tempsA-dBy/tempsB,tempsA);

            if (tmin<=0)
            {
                return -1;
            }
            //posicio al cap de tmin
            double Ax = PosA.GetX() + dAx / tempsA * tmin;
            double Ay = PosA.GetY() + dAy / tempsA * tmin;

            //vector de b fins a a
            double vectorx = Ax - PosB.GetX();
            double vectory = Ay - PosB.GetY();

            //eq 2n grau per trobar la velocitat de b pq no hi hagi conflicte
            double resultado = (vectorx*dBx+vectory* dBy)*(vectorx*dBx+vectory* dBy)-(dBx*dBx+dBy*dBy)*((vectorx*vectorx+vectory*vectory)-distanciaSeguridad*distanciaSeguridad);

            if (resultado < 0)
            {
                return -1;
            }
            //l'eq de segon grau ens donara dos resultats
            double res1=(vectorx+Math.Sqrt(resultado)) / (dBx * dBx + dBy * dBy);
            double res2 = (vectorx - Math.Sqrt(resultado)) / (dBx * dBx + dBy * dBy);

            double sActual = tmin / tempsB;

            // Quant s'allunya cada solució de la fracció actual
            double dif1 = res1 - sActual;
            double dif2 = res2 - sActual;

            // Si la diferència és negativa, la fem positiva (això és el valor absolut)
            if (dif1 < 0)
            {
                dif1 = -dif1;
            }
            if (dif2 < 0)
            {
                dif2 = -dif2;
            }

            // Triem la solució més propera a l'actual
            double s;
            if (dif1 < dif2)
            {
                s = res1;
            }
            else
            {
                s = res2;
            }
            if (s <= 0)
            {
                return -1;
            }

            // velocitat = distància recorreguda / temps
            return distB * s / tmin * 60;
        }
        public bool HabraConflicto(double tiempoCiclo, double distanciaSeguridad)
        {
            List<FlightPlan> copias = new List<FlightPlan>();

            // creem una llista exactament igual a la original només per simularla individualment i det. si hi haura conf en la trajectoria sense moure originals
            int i = 0;

            while (i < vector.Count)
            {
                FlightPlan original = vector[i];

                FlightPlan copia = new FlightPlan(
                    original.GetId(),
                    original.GetCurrentPosition().GetX(),
                    original.GetCurrentPosition().GetY(),
                    original.GetFinalPosition().GetX(),
                    original.GetFinalPosition().GetY(),
                    original.GetVelocidad()
                );

                copias.Add(copia);
                i++;
            }

            int ciclos = 0;
            int maxCiclos = 100000;

            // amb buscar det si hi ha conflicte ja de primeres
            bool conflicto = false;

            i = 0;
            while (i < copias.Count && conflicto == false)
            {
                int j = i + 1;

                while (j < copias.Count && conflicto == false)
                {
                    if (copias[i].Conflicto(copias[j], distanciaSeguridad))
                        conflicto = true;

                    j++;
                }

                i++;
            }

            bool seguirSimulando = true;

            // els vols o arriven o conflicte
            while (conflicto == false && ciclos < maxCiclos && seguirSimulando == true)
            {
                bool todosHanLlegado = true;

                i = 0;

                while (i < copias.Count) //simular tots fins que arriven
                {
                    if (copias[i].HasArrived() == false)
                    {
                        todosHanLlegado = false;
                        copias[i].Mover(tiempoCiclo);
                    }

                    i++;
                }

                if (todosHanLlegado == true)
                {
                    seguirSimulando = false;
                }
                else //comprovem els q no han arrivat
                {
                    i = 0;

                    while (i < copias.Count && conflicto == false)
                    {
                        int j = i + 1;

                        while (j < copias.Count && conflicto == false)
                        {
                            if (copias[i].Conflicto(copias[j], distanciaSeguridad))
                                conflicto = true;

                            j++;
                        }

                        i++;
                    }

                    ciclos++;
                }
            }
            return conflicto;
        }

        public bool ResolverConflictosLista(double distanciaSeguridad)
        {
            // Resolem els conflictes en una llista nova i mirem es poden resoldre avans de aplicar els canvis a la nostre.
            FlightPlanList copias = new FlightPlanList();

            int i = 0;

            while (i < vector.Count)
            {
                FlightPlan original = vector[i];

                FlightPlan copia = new FlightPlan(
                    original.GetId(),
                    original.GetCurrentPosition().GetX(),
                    original.GetCurrentPosition().GetY(),
                    original.GetFinalPosition().GetX(),
                    original.GetFinalPosition().GetY(),
                    original.GetVelocidad()
                );

                copias.AddFlightPlan(copia);
                i++;
            }

            bool hayConflicto = false;

            i = 0;

            while (i < copias.GetListSize())
            {
                int j = i + 1;

                while (j < copias.GetListSize())
                {
                    hayConflicto = false;
                    if (copias.GetFlightPlan(i).DistanciaMinima(copias.GetFlightPlan(j)) < distanciaSeguridad)
                    {
                        hayConflicto = true;

                        // Calculem la velocitat nova del vol j
                        double nuevaVelocidad = VelocidadSegura(copias.GetFlightPlan(i),
                                                                copias.GetFlightPlan(j),
                                                                distanciaSeguridad);

                        // Si ha retornat -1, no toquem res
                        if (nuevaVelocidad > 0)
                        {
                            copias.GetFlightPlan(j).SetVelocidad(nuevaVelocidad);
                        }
                    }

                    j++;
                }

                i++;
            }

            // queda algun conflicte?
            i = 0;
            while (i < copias.GetListSize())
            {
                int j = i + 1;

                while (j < copias.GetListSize())
                {
                    if (copias.GetFlightPlan(i).DistanciaMinima(copias.GetFlightPlan(j)) < distanciaSeguridad)
                    {
                        hayConflicto = true;
                    }

                    j++;
                }

                i++;
            }

            // apliquem velocitats
            if (hayConflicto == false)
            {
                i = 0;
                while (i < vector.Count)
                {
                    vector[i].SetVelocidad(copias.GetFlightPlan(i).GetVelocidad());
                    i++;
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public void leerFichero(string fichero)
        {

            StreamReader R = new StreamReader(fichero);

            string linea = R.ReadLine();
            while (linea != null)
            {
                string[] trozos = linea.Split(' ');
                FlightPlan F = new FlightPlan(trozos[0], Convert.ToDouble(trozos[1]),
                    Convert.ToDouble(trozos[2]), Convert.ToDouble(trozos[3]), Convert.ToDouble(trozos[4]), 
                    Convert.ToDouble(trozos[5]));
                vector.Add(F);

                linea = R.ReadLine();
            }

            R.Close();

        }

        public List<Position> GuardarPosiciones()
        {
            List<Position> posiciones = new List<Position>();
            for (int i = 0; i < vector.Count; i++)
            {
                posiciones.Add(vector[i].GetCurrentPosition());
            }
            return posiciones;
        } 

        public void RestaurarPosiciones(List<Position> posiciones)
        {
            for (int i = 0; i < vector.Count; i++)
            {
                vector[i].SetCurrentPosition(posiciones[i]);
            }
        }
    }
}


  

