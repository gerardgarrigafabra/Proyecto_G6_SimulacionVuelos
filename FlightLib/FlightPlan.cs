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
        
        
        private double DistanciaTramo(double rx, double ry, double vx, double vy, double duracion)
        {
            double velocidadCuadrado = vx * vx + vy * vy;
            double tiempo = 0;

            if (velocidadCuadrado > 0)
            {
                tiempo = -(rx * vx + ry * vy) / velocidadCuadrado;
            }

            // El mínimo ha d'estar dins tram
            if (tiempo < 0)
                tiempo = 0;
            if (tiempo > duracion)
                tiempo = duracion;

          
            double x = rx + vx * tiempo;
            double y = ry + vy * tiempo;

            return Math.Sqrt(x * x + y * y);

        }
        public double DistanciaMinima(FlightPlan otro)
        {
            Position posicionA = this.GetCurrentPosition();
            Position posicionB = otro.GetCurrentPosition();

            // Posición de A respecte  B
            double rx = posicionA.GetX() - posicionB.GetX();
            double ry = posicionA.GetY() - posicionB.GetY();

            // El que falta a cada vol per arribar final
            double dxA = this.GetFinalPosition().GetX() - posicionA.GetX();
            double dyA = this.GetFinalPosition().GetY() - posicionA.GetY();
            double dxB = otro.GetFinalPosition().GetX() - posicionB.GetX();
            double dyB = otro.GetFinalPosition().GetY() - posicionB.GetY();
            double distanciaA = posicionA.Distancia(this.GetFinalPosition());
            double distanciaB = posicionB.Distancia(otro.GetFinalPosition());

            
            bool seMueveA = distanciaA > 0 && this.GetVelocidad() > 0;
            bool seMueveB = distanciaB > 0 && otro.GetVelocidad() > 0;

            // Velocidad en x i y  i temps que tarda en arribar cada vuelo
            double vAx = 0;
            double vAy = 0;
            double vBx = 0;
            double vBy = 0;
            double tiempoLlegadaA = 0;
            double tiempoLlegadaB = 0;

            if (seMueveA)
            {
                vAx = dxA / distanciaA * this.GetVelocidad() / 60;
                vAy = dyA / distanciaA * this.GetVelocidad() / 60;
                tiempoLlegadaA = distanciaA / (this.GetVelocidad() / 60);
            }
            if (seMueveB)
            {
                vBx = dxB / distanciaB * otro.GetVelocidad() / 60;
                vBy = dyB / distanciaB * otro.GetVelocidad() / 60;
                tiempoLlegadaB = distanciaB / (otro.GetVelocidad() / 60);
            }

            
            double distanciaMinima = this.Distancia(otro);

            // Primer tram--> fins que arriba el primer dels dos 
            double duracionPrimerTramo = 0;
            if (seMueveA && seMueveB)
            {
                if (tiempoLlegadaA < tiempoLlegadaB)
                    duracionPrimerTramo = tiempoLlegadaA;
                else
                    duracionPrimerTramo = tiempoLlegadaB;
            }
            else if (seMueveA)
                duracionPrimerTramo = tiempoLlegadaA;
            else if (seMueveB)
                duracionPrimerTramo = tiempoLlegadaB;

            if (duracionPrimerTramo > 0)
            {
                double d1 = DistanciaTramo(rx, ry, vAx - vBx, vAy - vBy, duracionPrimerTramo);
                if (d1 < distanciaMinima)
                    distanciaMinima = d1;
            }

            // Segon tram: uno ja ha arribat i l'altre segueix movent-se
            if (seMueveA && seMueveB)
            {
                if (tiempoLlegadaA < tiempoLlegadaB)
                {
                    // Suposem que A ha arribat, B continua
                    double rxSegundo = this.GetFinalPosition().GetX() - (posicionB.GetX() + vBx * tiempoLlegadaA);
                    double rySegundo = this.GetFinalPosition().GetY() - (posicionB.GetY() + vBy * tiempoLlegadaA);

                    double d2 = DistanciaTramo(rxSegundo, rySegundo, -vBx, -vBy, tiempoLlegadaB - tiempoLlegadaA);
                    if (d2 < distanciaMinima)
                        distanciaMinima = d2;
                }
                else if (tiempoLlegadaB < tiempoLlegadaA)
                {
                    // Suposem que B ha arribat, A continua
                    double rxSegundo = posicionA.GetX() + vAx * tiempoLlegadaB - otro.GetFinalPosition().GetX();
                    double rySegundo = posicionA.GetY() + vAy * tiempoLlegadaB - otro.GetFinalPosition().GetY();

                    double d2 = DistanciaTramo(rxSegundo, rySegundo, vAx, vAy, tiempoLlegadaA - tiempoLlegadaB);
                    if (d2 < distanciaMinima)
                        distanciaMinima = d2;
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
