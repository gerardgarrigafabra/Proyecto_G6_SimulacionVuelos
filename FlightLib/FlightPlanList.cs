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
        Stack<List<Position>> historialposiciones = new Stack<List<Position>>(); // per tirar cap enrere

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
            historialposiciones.Clear();
        }

        public void Mover(double tiempo)
        {
            historialposiciones.Push(GuardarPosiciones()); // Guardem les posicions abans de moure els avions
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

        // Funció que itera el detector de futurs conflictes per tota la llista
        public bool HayConflictoFuturo(double distanciaSeguridad)
        {
            int i = 0;

            while (i < vector.Count)
            {
                int j = i + 1;

                while (j < vector.Count)
                {
                    if (vector[i].ConflictoFuturo(vector[j], distanciaSeguridad))
                        return true;

                    j++;
                }

                i++;
            }

            return false;
        }

        // Funció que itera la correcció de velocitat per tota la llista
        public bool ResolverConflictosLista(double distanciaSeguridad)
        {
            // 1. Creem una còpia de la llista actual per provar les correccions sense alterar els originals encara
            List<FlightPlan> copias = new List<FlightPlan>();
            for (int k = 0; k < vector.Count; k++)
            {
                FlightPlan orig = vector[k];
                FlightPlan copia = new FlightPlan(
                    orig.GetId(),
                    orig.GetCurrentPosition().GetX(),
                    orig.GetCurrentPosition().GetY(),
                    orig.GetFinalPosition().GetX(),
                    orig.GetFinalPosition().GetY(),
                    orig.GetVelocidad()
                );
                copia.SetCompany(orig.GetCompany());
                copias.Add(copia);
            }

            int maxIntentos = 20; // Límit d'iteracions per evitar bucles infinits si dos vols tenen un conflicte irresoluble
            int intento = 0;
            bool quedanConflictos = true;

            // 2. Iterem mentre hi hagi conflictes i no superem el màxim d'intents
            while (quedanConflictos && intento < maxIntentos)
            {
                quedanConflictos = false;

                for (int i = 0; i < copias.Count; i++)
                {
                    for (int j = i + 1; j < copias.Count; j++)
                    {
                        // Comprovem si aquest parell de vols entrarà en conflicte en el futur
                        if (copias[i].ConflictoFuturo(copias[j], distanciaSeguridad))
                        {
                            // Calculem la nova velocitat segura per al segon vol (j) respecte al primer (i)
                            // Nota: afegim un petit marge de seguretat (ex: + 0.01) per evitar errors de precisió decimal en tornar a comprovar
                            double nuevaVel = copias[i].VelocidadSegura(copias[j], distanciaSeguridad + 0.01);

                            if (nuevaVel > 0)
                            {
                                copias[j].SetVelocidad(nuevaVel);
                                // Com que hem modificat una velocitat, marquem que hem de tornar a revisar tota la llista
                                // per assegurar-nos que aquest canvi no ha provocat un nou conflicte amb un tercer vol
                                quedanConflictos = true;
                            }
                        }
                    }
                }
                intento++;
            }

            // 3. Verificació final: Comprovem si després de les iteracions realment ja no queda cap conflicte a les còpies
            bool hayAlgunConflictoFinal = false;
            for (int i = 0; i < copias.Count; i++)
            {
                for (int j = i + 1; j < copias.Count; j++)
                {
                    if (copias[i].ConflictoFuturo(copias[j], distanciaSeguridad))
                    {
                        hayAlgunConflictoFinal = true;
                        break;
                    }
                }
                if (hayAlgunConflictoFinal) break;
            }

            // 4. Si s'han resolt tots els conflictes satisfactòriament, apliquem les noves velocitats als vols originals
            if (!hayAlgunConflictoFinal)
            {
                for (int i = 0; i < vector.Count; i++)
                {
                    vector[i].SetVelocidad(copias[i].GetVelocidad());
                }
                return false; // Tots els conflictes resolts
            }

            return true; // No s'ha pogut trobar una combinació sense conflictes (els vols originals queden intactes)
        }


        public bool leerFichero(string fichero)
        {
            StreamReader R = new StreamReader(fichero);

            string linea = R.ReadLine();

            while (linea != null)
            {
                string[] trozos = linea.Split(' ');

                if (linea != "")
                {
                    if (trozos.Length == 7)
                    {
                        FlightPlan F = new FlightPlan(trozos[0], Convert.ToDouble(trozos[2]),
                            Convert.ToDouble(trozos[3]), Convert.ToDouble(trozos[4]), Convert.ToDouble(trozos[5]),
                            Convert.ToDouble(trozos[6]));

                        F.SetCompany(trozos[1]);
                        vector.Add(F);
                    }
                    else
                    {
                        R.Close();
                        return false;
                    }
                }

                linea = R.ReadLine();
            }

            R.Close();
            return true;
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

        public bool DeshacerPaso()
        {
            if (historialposiciones.Count > 0)
            {
                RestaurarPosiciones(historialposiciones.Pop());
                return true;
            }
            else
            {
                return false;
            }
        }
        public void guardarFichero(string fichero)
        {
            StreamWriter W = new StreamWriter(fichero);

            int i = 0;
            while (i < vector.Count)
            {
                FlightPlan F = vector[i];

                // id companyia posiciónActualX posiciónActualY destinoX destinoY velocitat
                W.WriteLine(F.GetId() + " " + F.GetCompany() + " " +
                    F.GetCurrentPosition().GetX() + " " + F.GetCurrentPosition().GetY() + " " +
                    F.GetFinalPosition().GetX() + " " + F.GetFinalPosition().GetY() + " " +
                    F.GetVelocidad());

                i = i + 1;
            }

            W.Close();
        }
    }
}


  

