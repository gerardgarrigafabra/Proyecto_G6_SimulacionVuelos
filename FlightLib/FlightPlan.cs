using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos

        string id; // identificador
        Position initialPosition; //Posicion inicial
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        double velocidad;

        // Constructures
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.currentPosition = new Position(cpx, cpy);
            this.initialPosition = this.currentPosition;
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
        }

        // Metodos
        public void SetId(string id)
        {
            this.id = id;
        }
        public string GetId()
        {
            return this.id;
         }

        public void SetVelocidad(double velocidad) // setter del atributo velocidad
        {
            this.velocidad = velocidad;
        }
        public double GetVelocidad()
        {
            return this.velocidad;
        }

        public void SetInitialPosition(Position initialPosition)
        {
            this.initialPosition = initialPosition;
        }

        public Position GetInitialPosition()
        {
            return this.initialPosition;
        }

        public void SetCurrentPosition(Position currentPosition)
        {
            this.currentPosition = currentPosition;
        }
        
        public Position GetCurrentPosition()
        {
            return this.currentPosition;
        }        

        public void SetFinalPosition(Position finalPosition)
        {
            this.finalPosition = finalPosition;
        }

        public Position GetFinalPosition()
        {
            return this.finalPosition;
        }

        // Restart
        public void Restart()
        {
            this.currentPosition = this.initialPosition;
        }

        public double Distancia(FlightPlan plan)
        {
            return this.currentPosition.Distancia(plan.currentPosition);
        }



        public void Mover(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //Calculamos las razones trigonométricas
            double hipotenusa = currentPosition.Distancia(finalPosition);
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            Position nextPosition = new Position(x, y);

            if (currentPosition.Distancia(nextPosition) < hipotenusa)
                currentPosition = nextPosition;
            else
                currentPosition = finalPosition;

        }

        public bool HasArrived()
        {
            bool resultado = false;
            if (currentPosition == finalPosition)
                resultado = true;
            
            return resultado;
        }
        // distancia min x segment
        private void ComprobarTramo(
            double rx, double ry,
            double vx, double vy,
            double duracion,
            double tiempoInicio,
            ref double distanciaMinima,
            ref double tiempoMinimo) //ref pq no pren valor det
        {
            double velocidadCuadrado = vx * vx + vy * vy;
            double tiempo = 0;

            if (velocidadCuadrado > 0)
            {
                // Igualamos la derivada a cero y despejamos el tiempo
                tiempo = -(rx * vx + ry * vy) / velocidadCuadrado; // (x,y) + vt per a cda pt //REVISAR
            }
            if (tiempo < 0)
                tiempo = 0;

            if (tiempo > duracion)
                tiempo = duracion;

            // dist recorreguda en el temps equivalent al min.
            double x = rx + vx * tiempo;
            double y = ry + vy * tiempo;

            double distancia = Math.Sqrt(x * x + y * y);

            // Actualizamos si hemos encontrado una distancia menor
            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                tiempoMinimo = tiempoInicio + tiempo;
            }
        }
        // Calculem dist min amb la funció de dist derivada i igualada a 0
        public double DistanciaMinima(FlightPlan otro, out double tiempoMinimo)
        {
            Position posicionA = this.GetCurrentPosition();
            Position posicionB = otro.GetCurrentPosition();

            double rx = posicionA.GetX() - posicionB.GetX();
            double ry = posicionA.GetY() - posicionB.GetY();

            double dxA = this.GetFinalPosition().GetX() - posicionA.GetX();
            double dyA = this.GetFinalPosition().GetY() - posicionA.GetY();

            double dxB = otro.GetFinalPosition().GetX() - posicionB.GetX();
            double dyB = otro.GetFinalPosition().GetY() - posicionB.GetY();

            double distanciaA = Math.Sqrt(dxA * dxA + dyA * dyA);
            double distanciaB = Math.Sqrt(dxB * dxB + dyB * dyB);

            bool seMueveA = distanciaA > 0 && this.GetVelocidad() > 0;
            bool seMueveB = distanciaB > 0 && otro.GetVelocidad() > 0;

            double vAx = 0;
            double vAy = 0;
            double vBx = 0;
            double vBy = 0;

            if (seMueveA)
            {
                vAx = dxA / distanciaA * this.GetVelocidad() / 60;
                vAy = dyA / distanciaA * this.GetVelocidad() / 60;
            }

            if (seMueveB)
            {
                vBx = dxB / distanciaB * otro.GetVelocidad() / 60;
                vBy = dyB / distanciaB * otro.GetVelocidad() / 60;
            }

            double tiempoLlegadaA = 0;
            double tiempoLlegadaB = 0;

            if (seMueveA)
                tiempoLlegadaA = distanciaA / (this.GetVelocidad() / 60);

            if (seMueveB)
                tiempoLlegadaB = distanciaB / (otro.GetVelocidad() / 60);

            double distanciaMinima = Math.Sqrt(rx * rx + ry * ry);
            tiempoMinimo = 0;

            double duracionPrimerTramo = 0;

            if (seMueveA && seMueveB)
                duracionPrimerTramo = Math.Min(tiempoLlegadaA, tiempoLlegadaB); //.min pilla el minim
            else if (seMueveA)
                duracionPrimerTramo = tiempoLlegadaA;
            else if (seMueveB)
                duracionPrimerTramo = tiempoLlegadaB;

            //si hi ha moviment
            if (duracionPrimerTramo > 0)
            {
                ComprobarTramo(
                    rx, ry,
                    vAx - vBx, vAy - vBy,
                    duracionPrimerTramo, 0,
                    ref distanciaMinima, ref tiempoMinimo
                );
            }

            // Segundo tramo: uno de los aviones ya ha llegado
            if (seMueveA && seMueveB)
            {
                if (tiempoLlegadaA < tiempoLlegadaB)
                {
                    // El avion A ha llegado y el B continua moviendose
                    double rxSegundo = this.GetFinalPosition().GetX()
                        - (posicionB.GetX() + vBx * tiempoLlegadaA);

                    double rySegundo = this.GetFinalPosition().GetY()
                        - (posicionB.GetY() + vBy * tiempoLlegadaA);

                    double duracionSegundo = tiempoLlegadaB - tiempoLlegadaA;

                    ComprobarTramo(
                        rxSegundo, rySegundo,
                        -vBx, -vBy,
                        duracionSegundo, tiempoLlegadaA,
                        ref distanciaMinima, ref tiempoMinimo
                    );
                }
                else if (tiempoLlegadaB < tiempoLlegadaA)
                {
                    // El avion B ha llegado y el A continua moviendose
                    double rxSegundo = posicionA.GetX() + vAx * tiempoLlegadaB
                        - otro.GetFinalPosition().GetX();

                    double rySegundo = posicionA.GetY() + vAy * tiempoLlegadaB
                        - otro.GetFinalPosition().GetY();

                    double duracionSegundo = tiempoLlegadaA - tiempoLlegadaB;

                    ComprobarTramo(
                        rxSegundo, rySegundo,
                        vAx, vAy,
                        duracionSegundo, tiempoLlegadaB,
                        ref distanciaMinima, ref tiempoMinimo
                    );
                }
            }

            return distanciaMinima;
        }
        public bool Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;
            if (this.Distancia(b) < distanciaSeguridad)
                conflicto = true;
            return conflicto;
        }

        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0:F2}", id);
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if(this.HasArrived())
                Console.WriteLine("Ha llegado al destino");
            Console.WriteLine("******************************");
        }

    }
}
