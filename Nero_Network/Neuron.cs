using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nero_Network
{
    public class Neuron
    {
        public float Error;
        public float Output;
        public bool guess;
        public float[] weight;
        public int index;
        public Type type;
        public enum Type
        {
            hidden, output
        }

        public Neuron(int N, int i, Type t)
        {
            weight = new float[N];
            index = i;
            type = t;
        }

        public void CalculateOutputOut(float[] X, float a)
        {
            float S = 0;
            int length = X.Length;
            for (int i = 0; i < length; i++)
            {
                S += X[i] * weight[i];
            }
            Output = 1f / (1 + (float)Math.Pow(Math.E, -a * S));
        }
        public void CalculateOutputHid(int[] X, float a)
        {
            float S = 0;
            int length = X.Length;
            for (int i = 0; i < length; i++)
            {
                if (X[i] != 0)
                {
                    S += X[i] * weight[i];
                }
            }
            Output = 1f / (1 + (float)Math.Pow(Math.E, -a * S));
        }

        public void ChangeWeight(float Alpha, float Err, float Out, float Op, int Index)
        {
            weight[Index] -= Alpha * Err * Out * (1f - Out) * Op;
        }

        public void CalculateErrorOut(int d)
        {
            Error = Output - d;
        }
        public void CalculateErrorHid(float ErrOut, float Out, float Wn)
        {
            Error += ErrOut * Out * (1f - Out) * Wn;
        }

        public void SaveWeight()
        {
            StreamWriter save = new StreamWriter($"Weights/{Form1.folder}/Weight({type})-{index}.txt");
            for (int i = 0; i < weight.Length; i++)
            {
                save.WriteLine(weight[i]);
            }
            save.Close();
        }
        public void LoadWeight()
        {
            if (File.Exists($"Weights/{Form1.folder}/Weight({type})-{index}.txt"))
            {
                StreamReader load = new StreamReader($"Weights/{Form1.folder}/Weight({type})-{index}.txt");
                for (int i = 0; i < weight.Length; i++)
                {
                    weight[i] = Convert.ToSingle(load.ReadLine());
                }
                load.Close();
            }
        }        
    }
}
