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
                string company = "-";

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
                public void SetCompany(string company)
                {
                    this.company = company;
                }

                public string GetCompany()
                {
                    return this.company;
                }

                // Restart
                public void Restart()
                {
                    this.currentPosition = this.initialPosition;
                }

                // Distancia entre dos vuelos
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
                    // La nueva posicion la aplicamos si aun no hemos llegado al final
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
                
                //Funcio que calcula, amb la derivada de la funció de moviment, el temps que tardaràn en arribar.
                public double TiempoMinimo(double rx, double ry, double vx, double vy, double duracion)
                {
                    double velocidadCuadrado = vx * vx + vy * vy;
                    double tiempo = 0;

                    if (velocidadCuadrado > 0)
                    {
                        tiempo = -(rx * vx + ry * vy) / velocidadCuadrado;
                    }

                    if (tiempo < 0)
                        tiempo = 0;
                    if (tiempo > duracion)
                        tiempo = duracion;
                    return tiempo;
                }
                // distancia minima x segment

                public double DistanciaTramo(double rx, double ry, double vx, double vy, double duracion)
                {
                    double tiempo = TiempoMinimo(rx, ry, vx, vy, duracion);


                    double x = rx + vx * tiempo;
                    double y = ry + vy * tiempo;

                    return Math.Sqrt(x * x + y * y);

                }

        // Funció que calcula la distancia mínima entre dos vols, tenint en compte que poden arribar a la seva destinació abans que l'altre
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

                    // Segon tram: un ja ha arribat i l'altre segueix movent-se
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

                // Funció per comprovar si hi haurà un conflicte en el futur amb un altre vol
                public bool ConflictoFuturo(FlightPlan otro, double distanciaSeguridad)
                {
                    return this.DistanciaMinima(otro) < distanciaSeguridad;
                }

                // Funció per calcular la velocitat segura respecte a un altre vol
                public double VelocidadSegura(FlightPlan otro, double distanciaSeguridad)
                {
                    Position PosA = this.GetCurrentPosition();
                    Position PosB = otro.GetCurrentPosition();

                    // Distància que li queda al final
                    double distA = PosA.Distancia(this.GetFinalPosition());
                    double distB = PosB.Distancia(otro.GetFinalPosition());

                    double velA = this.GetVelocidad() / 60.0;
                    double velB = otro.GetVelocidad() / 60.0;

                    if (distA == 0 || distB == 0 || velA == 0 || velB == 0)
                        return -1;

                    double tempsA = distA / velA;
                    double tempsB = distB / velB;

                    // Vectors de desplaçament total que li falta a cada vol
                    double dAx = this.GetFinalPosition().GetX() - PosA.GetX();
                    double dAy = this.GetFinalPosition().GetY() - PosA.GetY();
                    double dBx = otro.GetFinalPosition().GetX() - PosB.GetX();
                    double dBy = otro.GetFinalPosition().GetY() - PosB.GetY();

                    // Velocitats actuals en components
                    double vAx = dAx / tempsA;
                    double vAy = dAy / tempsA;
                    double vBx = dBx / tempsB;
                    double vBy = dBy / tempsB;

                    // Temps on estan més a prop actualment
                    double rx = PosA.GetX() - PosB.GetX();
                    double ry = PosA.GetY() - PosB.GetY();
                    double tmin = this.TiempoMinimo(rx, ry, vAx - vBx, vAy - vBy, Math.Min(tempsA, tempsB));

                    if (tmin <= 0)
                        return -1;

                    // Posició de A en el moment del conflicte (tmin)
                    double Ax = PosA.GetX() + vAx * tmin;
                    double Ay = PosA.GetY() + vAy * tmin;

                    // Vector des de la posició inicial de B fins a la posició de A en tmin
                    double vectorx = Ax - PosB.GetX();
                    double vectory = Ay - PosB.GetY();

                    // Coeficients de l'equació de 2n grau: A*s^2 + B*s + C = 0
                    // On 's' és la fracció del recorregut que ha de fer B en el temps tmin per quedar a distància exacta = distanciaSeguridad
                    double A = dBx * dBx + dBy * dBy;
                    double B = -2.0 * (vectorx * dBx + vectory * dBy);
                    double C = (vectorx * vectorx + vectory * vectory) - (distanciaSeguridad * distanciaSeguridad);

                    double discriminant = B * B - 4.0 * A * C;

                    if (discriminant < 0)
                        return -1;

                    // Les dues solucions exactes on la distància és igual a distanciaSeguridad
                    double s1 = (-B + Math.Sqrt(discriminant)) / (2.0 * A);
                    double s2 = (-B - Math.Sqrt(discriminant)) / (2.0 * A);

                    double sActual = tmin / tempsB;

                    // Triem la solució més gran que sigui menor que l'actual (frenar el mínim imprescindible)
                    double s = -1;
                    if (s1 > 0 && s1 < sActual && s2 > 0 && s2 < sActual)
                        s = Math.Max(s1, s2);
                    else if (s1 > 0 && s1 < sActual)
                        s = s1;
                    else if (s2 > 0 && s2 < sActual)
                        s = s2;

                    if (s <= 0)
                        return -1;

                    // Velocitat exacta en unitats/hora
                    return (distB * s / tmin) * 60.0;
                }

                // Funció per solucionar el conflicte modificant la velocitat de l'altre vol ('otro')
                public bool SolucionarConflicte(FlightPlan otro, double distanciaSeguridad)
                {
                    double nuevaVelocidad = this.VelocidadSegura(otro, distanciaSeguridad);

                    if (nuevaVelocidad > 0)
                    {
                        otro.SetVelocidad(nuevaVelocidad);
                        return true;
                    }

                return false;
                }


                // Funció per comprovar si hi ha un conflicte amb un altre vol
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
