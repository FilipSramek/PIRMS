﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using DataMaker_R3;
using System.Numerics;

namespace DataMaker_R3
{   
    /// <summary>
    /// Na to aby třída fungovala správě je první potřeba spočíat komplecní vídledek fft a až z kkomplexního výsledku vypočítat fáze a magnitudy
    /// </summary>
    public class Fft
    {
        public override string ToString()
        {
            return "FFT: GetComplex(), GetPhases(), GetMagintudes()";
        }
        //TO-DO:
        /* přidat settings do compute pro různé možnosti exportů a ušetření paměti
         * 
         */
        private List<Complex32> complexResult = new List<Complex32>();
        private List<double> magnitudesResult = new List<double>();
        private List<double> phasesResult = new List<double>();

        private List<Complex32> Compute(List<double> inputSignal)
        {
            if (inputSignal == null || inputSignal.Count == 0)
                return null;
                throw new ArgumentException("Input signal cannot be null or empty.");

            if (inputSignal.Count != 100)
                return null;
                throw new ArgumentException("Input signal must contain exactly 100 samples.");

            // Convert input to Complex32[]
            Complex32[] complexSignal = new Complex32[inputSignal.Count];
            for (int i = 0; i < inputSignal.Count; i++)
            {
                complexSignal[i] = new Complex32((float)inputSignal[i], 0f); // Explicitly cast double to float
            }

            // Perform FFT
            Fourier.Forward(complexSignal, FourierOptions.Matlab);
            // Add this using directive at the top of your file
            // Return as List
            return new List<Complex32>(complexSignal);
        }

        public List<Complex32> GetComplex(List<double> inputSignal)
        {
             complexResult = this.Compute(inputSignal);
             return complexResult;
        }

        public List<double> GetMagnitudes(List<Complex32> complexResult)
        {
            if (complexResult == null)
            {
                return null;
            }
            
            List<double> magnitudes = new List<double>(complexResult.Count);
            foreach (var c in complexResult)
            {
                magnitudes.Add(c.Magnitude);
            }
            return magnitudes;
        }

        public List<double> GetPhases(List<Complex32> complexResult)
        {
            if (complexResult == null)
            {
                return null;
            }
            List<double> phases = new List<double>(complexResult.Count);
            foreach (var c in complexResult)
            {
                phases.Add(c.Phase);
            }
            return phases;
        }
    }
}
