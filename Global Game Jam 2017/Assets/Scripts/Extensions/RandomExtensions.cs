﻿using System;
using UnityEngine;

namespace Extensions.UnityEngine
{
    public static class RandomUtil
    {
        // ---- ---- ---- ---- ---- ---- ---- ----
        // Propiedades
        // ---- ---- ---- ---- ---- ---- ---- ----
        /// <summary>
        /// Devuelve un valor booleano aleatorio con una distribución uniforme.
        /// </summary>
        public static bool NextBoolean
        {
            get { return global::UnityEngine.Random.value > 0.5f; }
        }
        
        // ---- ---- ---- ---- ---- ---- ---- ----
        // Métodos
        // ---- ---- ---- ---- ---- ---- ---- ----
        /// <summary>
        /// Genera un número aleatorio siguiendo una distribución normal o gaussiana, con forma de campana.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="mu">Valor medio de la distribución normal.</param>
        /// <param name="sigma">Desviación típica de la distribución normal.</param>
        /// <returns></returns>
        public static float NextGaussian(float mu = 0, float sigma = 1)
        {
            float u1 = global::UnityEngine.Random.value;
            float u2 = global::UnityEngine.Random.value;
            
            float rand_std_normal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);
            
            return mu + sigma * rand_std_normal;
        }
        
        /// <summary>
        /// Genera un número aleatorio siguiendo una distribución triangular.
        /// </summary>
        /// <remarks>
        /// Ver enlace: http://en.wikipedia.org/wiki/Triangular_distribution para una descripción de la distribución de
        /// probabilidades triangular y del algoritmo para generarlo.
        /// </remarks>
        /// <param name = "min">Valor mínimo de la distribución.</param>
        /// <param name = "max">Valor máximo de la distribución.</param>
        /// <param name = "mode">Moda de la distribución (el valor más frecuente).</param>
        /// <returns></returns>
        public static float NextTriangular(float min, float max, float mode)
        {
            float u = global::UnityEngine.Random.value;
            
            return u < (mode - min) / (max - min)
                       ? min + Mathf.Sqrt(u * (max - min) * (mode - min))
                       : max - Mathf.Sqrt((1 - u) * (max - min) * (max - mode));
        }
        
        /// <summary>
        /// Devuelve un valor booleano aleatorio, con la probabilidad especificada de tener el valor 'true'.
        /// </summary>
        /// <param name = "probability">Probabilidad entre cero y uno de devolver 'true'.</param>
        public static bool Chance(float probability)
        {
            return global::UnityEngine.Random.value < probability;
        }
        
        /// <summary>
        /// Devuelve uno de los elementos de una enumeración elegido al azar, con una distribución uniforme.
        /// </summary>
        public static T NextEnum<T>() where T : struct
        {
            Array enumValues = Enum.GetValues(typeof(T));
            int index = global::UnityEngine.Random.Range(0, enumValues.Length);
            return (T)enumValues.GetValue(index);
        }

       
    }
    
}