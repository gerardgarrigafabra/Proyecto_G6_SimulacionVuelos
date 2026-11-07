using System;
using System.Collections.Generic;
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
    }
}


  

