﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion = 0, Laboratorio, Legislacion, SPD
        }

        private List<Alumno> alumnos = new List<Alumno>();
        private List<Jornada> jornada = new List<Jornada>();
        private List<Profesor> profesores = new List<Profesor>();

        public List<Alumno> Alumnos
        {
            get {return this.alumnos; }
            set {this.alumnos = value; }
        }

        public List<Jornada> Jornadas 
        {
            get {return this.jornada; }
            set { this.jornada = value; }
        }

        public List<Profesor> Instructores
        {
            get {return this.profesores; }
            set { this.profesores = value; }
        }

        public Jornada this[int i]
        {
            get {return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }
        

        public Universidad()
        {
        }

        private static string MostrarDatos(Universidad gim)
        {
            return gim.Alumnos.ToString() + gim.Jornadas.ToString() + gim.Instructores.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach(Alumno i in g.Alumnos)
            {
                if(i == a)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach(Profesor p in g.profesores)
            {
                if(p == i)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if( g != a)
            {
                g.alumnos.Add(a);
            }
            return g;
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g!=i)
            {
                g.profesores.Add(i);
            }
            return g;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);
            g.Jornadas.Add(j);
            return g;
        }

        public static Profesor operator ==(Universidad g, EClases clase)
        {
                foreach (Profesor i in g.Instructores)
                {
                    if (i == clase)
                    {
                        return i;
                    }
                }

            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor i in g.Instructores)
            {
                if (i != clase)
                {
                    return i;
                }
            }

            return null;
        }

        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.guardar("Universidad.xml", gim);
        }
    }
}