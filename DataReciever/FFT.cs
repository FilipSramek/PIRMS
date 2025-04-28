using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.IntegralTransforms;
using MathNet.Numerics;

namespace DataReciever
{
    class FFT
    {
        /// <summary>
        /// Computes the Fast Fourier Transform (FFT) of a given input signal.
        /// </summary>
        /// <param name="inputSignal">A list of doubles representing the input signal in the time domain.</param>
        /// <returns>A list of doubles representing the magnitudes of the FFT output in the frequency domain.</returns>
        /// <exception cref="ArgumentException">Thrown if the input signal is null, empty, or does not contain exactly 100 samples.</exception>
        public List<double> ComputeMagnitude(List<double> inputSignal)
        {
            // Validate that the input signal is not null or empty.
            if (inputSignal == null || inputSignal.Count == 0)
                throw new ArgumentException("Input signal cannot be null or empty.");

            // Ensure the input signal contains exactly 100 samples.
            if (inputSignal.Count != 100)
                throw new ArgumentException("Input signal must contain exactly 100 samples.");

            // Convert the input signal into an array of Complex32 numbers.
            // Each input value is treated as the real part, with the imaginary part set to 0.
            Complex32[] complexSignal = new Complex32[inputSignal.Count];
            for (int i = 0; i < inputSignal.Count; i++)
            {
                complexSignal[i] = new Complex32((float)inputSignal[i], 0);
            }

            // Perform the FFT on the complex signal using the MathNet.Numerics library.
            // The FourierOptions.Matlab option ensures compatibility with MATLAB's FFT implementation.
            Fourier.Forward(complexSignal, FourierOptions.Matlab);

            // Create a list to store the magnitudes of the FFT output.
            List<double> outputMagnitudes = new List<double>(complexSignal.Length);

            // Calculate the magnitude of each complex number in the FFT output.
            // The magnitude represents the amplitude of each frequency component.
            for (int i = 0; i < complexSignal.Length; i++)
            {
                outputMagnitudes.Add(complexSignal[i].Magnitude);
            }

            // Return the list of magnitudes as the FFT result.
            return outputMagnitudes;
        }

        public List<double> ComputePhase(List<double> inputSignal)
        {
            // Validate that the input signal is not null or empty.
            if (inputSignal == null || inputSignal.Count == 0)
                throw new ArgumentException("Input signal cannot be null or empty.");

            // Ensure the input signal contains exactly 100 samples.
            if (inputSignal.Count != 100)
                throw new ArgumentException("Input signal must contain exactly 100 samples.");

            // Convert the input signal into an array of Complex32 numbers.
            // Each input value is treated as the real part, with the imaginary part set to 0.
            Complex32[] complexSignal = new Complex32[inputSignal.Count];
            for (int i = 0; i < inputSignal.Count; i++)
            {
                complexSignal[i] = new Complex32((float)inputSignal[i], 0);
            }

            // Perform the FFT on the complex signal using the MathNet.Numerics library.
            // The FourierOptions.Matlab option ensures compatibility with MATLAB's FFT implementation.
            Fourier.Forward(complexSignal, FourierOptions.Matlab);

            // Create a list to store the magnitudes of the FFT output.
            List<double> outputPhases = new List<double>(complexSignal.Length);

            // Calculate the magnitude of each complex number in the FFT output.
            // The magnitude represents the amplitude of each frequency component.
            for (int i = 0; i < complexSignal.Length; i++)
            {
                outputPhases.Add(complexSignal[i].Phase);
            }

            // Return the list of magnitudes as the FFT result.
            return outputPhases;
        }
    }
}
