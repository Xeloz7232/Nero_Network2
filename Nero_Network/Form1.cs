using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nero_Network
{
    public partial class Form1 : Form
    {
        #region Данные
        public static bool flag = false;
        public static float FuncCoaf;
        public static float startAlpha;
        public const int N = 10000;
        public static int tempSemples = -1;
        public static int lastHiddenSize;
        public static string[] NeuronNames;
        public static string folder;
        public static int OutputNeuronSize;
        public static int HiddenNeuronSize;
        public Neuron[] NeuronOutput;
        public Neuron[] NeuronHidden;
        public int lastX, lastY;
        public int[] X = new int[N];
        public static int SampleSize;
        public static int[][] SampleNormal;
        public static int[][] SampleCenter;
        public static int[][] SampleScale;
        public static int TestSize;
        public static int[][] TestNormal;
        public static int[][] TestCenter;
        public static int[][] TestScale;
        public static Random r = new Random();
        public int EpsilonDegree;
        public float epsilon;
        #endregion

        public Form1()
        {
            InitializeComponent();
            cbSamples.SelectedIndex = 2;
            EpsilonChange();
        }

        #region Рисование
        private void Clear()
        {
            pbMain.Image = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(pbMain.Image);
            g.Clear(Color.FromArgb(255, 255, 255, 255));
            lGuess.Text = string.Empty;
        }
        private void bClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void bGive_Click(object sender, EventArgs e)
        {
            var neuronsGuesses = new List<string>();
            string S = "";
            int summ = 0;
            if (rbCenter.Checked) pbMain.Image = Centering((Bitmap)pbMain.Image);
            else if (rbScale.Checked) pbMain.Image = Scaling((Bitmap)pbMain.Image);
            Bitmap bm = (Bitmap)pbMain.Image;
            float FuncCoaf = (float)nudFuncCoef.Value;
            bool isMistake = false;
            int guessC = 0;
            int curGuess = -1;
            float[] OutputsOfHidden = new float[HiddenNeuronSize];
            for (int i = 0; i < N; i++)
            {
                X[i] = bm.GetPixel(i % 100, i / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                summ += X[i];
            }
            if (summ > 0)
            {
                for (int i = 0; i < HiddenNeuronSize; i++)
                {
                    NeuronHidden[i].CalculateOutputHid(X, FuncCoaf);
                    OutputsOfHidden[i] = NeuronHidden[i].Output;
                }
                for (int i = 0; i < OutputNeuronSize; i++)
                {
                    NeuronOutput[i].CalculateOutputOut(OutputsOfHidden, FuncCoaf);
                    string aahhhhhh = NeuronOutput[i].Output >= 0.8f ? "Да" : NeuronOutput[i].Output <= 0.2f ? "Нет" : "Не понял";
                    neuronsGuesses.Add($"{NeuronNames[i]} : {NeuronOutput[i].Output} ({aahhhhhh})");
                    if (NeuronOutput[i].Output >= 0.8f && guessC == 0)
                    {
                        guessC++;
                        curGuess = i;
                    }
                    else if (NeuronOutput[i].Output >= 0.8f && guessC > 0)
                    {
                        guessC++;
                        curGuess = -1;
                    }
                    if (NeuronOutput[i].Output > 0.2f && NeuronOutput[i].Output < 0.8f)
                    {
                        isMistake = true;
                    }
                }
                if (isMistake)
                {
                    lGuess.Text = $"Не понимаю.";
                }
                else if (curGuess == -1)
                {
                    lGuess.Text = $"Распознало\n{guessC} нейронов";
                }
                else lGuess.Text = $"{NeuronNames[curGuess]}";
                foreach (var vvv in neuronsGuesses)
                {
                    //listBox1.Items.Add($"{vvv}");
                    S += $"{vvv}\n";
                }
                if (checkBox1.Checked)
                    MessageBox.Show($"{S}", "Результаты", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Поле пустое.", "Ошибка.", MessageBoxButtons.OK);
            }
        }
        private void pbMain_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X, y = e.Y;
            Pen p = new Pen(Color.Black, 5);
            Graphics g = Graphics.FromImage(pbMain.Image);
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(p, lastX, lastY, x, y);
            }
            p.Dispose(); g.Dispose();
            pbMain.Invalidate();
            lastX = x; lastY = y;
        }
        #endregion

        #region Обучение
        private void StartTraining()
        {
            #region Данные
            int nMax = (int)nudNMax.Value;
            bool isAccurate;
            float[] OutputsOfHidden = new float[HiddenNeuronSize];
            float EpsSampleError;
            float EpsEpochError;
            FuncCoaf = (float)nudFuncCoef.Value;
            //float FuncCoaf = 1;
            int[][] Sample = rbCenter.Checked ? SampleCenter : rbScale.Checked ? SampleScale : SampleNormal;
            float Alpha = (float)nudAlpha.Value;
            startAlpha = Alpha;
            lRight.Text = "Угадал";
            int Epoch = 0;
            Stopwatch stopWatch = new Stopwatch();
            if (!Directory.Exists($"Results/{cbSamples.Text}_A{startAlpha}_FC{FuncCoaf}_E{epsilon}_HNS{HiddenNeuronSize}_NMax{nudNMax.Value}"))
            { Directory.CreateDirectory($"Results/{cbSamples.Text}_A{startAlpha}_FC{FuncCoaf}_E{epsilon}_HNS{HiddenNeuronSize}_NMax{nudNMax.Value}"); }
            DirectoryInfo epochDirInfo = new DirectoryInfo($"Results/{cbSamples.Text}_A{startAlpha}_FC{FuncCoaf}_E{epsilon}_HNS{HiddenNeuronSize}_NMax{nudNMax.Value}");
            foreach (FileInfo file in epochDirInfo.GetFiles())
            { file.Delete(); }
            #endregion
            stopWatch.Start();
            for (int n = 0; n < OutputNeuronSize; n++)
            {
                for (int i = 0; i < HiddenNeuronSize; i++)
                {
                    NeuronOutput[n].weight[i] = r.Next(-30, 30) / 100f;
                }
            }
            for (int n = 0; n < HiddenNeuronSize; n++)
            {
                for (int i = 0; i < N; i++)
                {
                    NeuronHidden[n].weight[i] = r.Next(-30, 30) / 100f;
                }
            }
            do
            {
                Stopwatch epochWatch = new Stopwatch();
                epochWatch.Start();
                Epoch++;
                StreamWriter epochs = new StreamWriter($"Results/{cbSamples.Text}_A{startAlpha}_FC{FuncCoaf}_E{epsilon}_HNS{HiddenNeuronSize}_NMax{nudNMax.Value}/Эпоха({Epoch}).txt");
                EpsEpochError = 0;
                isAccurate = true;
                float[] countAccuracy = new float[SampleSize * OutputNeuronSize];
                int[] Counter = new int[Sample.GetLength(0)];
                for (int i = 0; i < Sample.GetLength(0); i++)
                {
                    Counter[i] = i;
                }
                epochs.WriteLine($"---Эпоха - { Epoch }---");
                while (Counter.Length > 0)
                {
                    EpsSampleError = 0;
                    int g = r.Next(0, Counter.Length);
                    for (int i = 0; i < HiddenNeuronSize; i++)
                    {
                        NeuronHidden[i].CalculateOutputHid(Sample[Counter[g]], FuncCoaf);
                        OutputsOfHidden[i] = NeuronHidden[i].Output;
                    }
                    for (int i = 0; i < OutputNeuronSize; i++)
                    {
                        NeuronOutput[i].CalculateOutputOut(OutputsOfHidden, FuncCoaf);
                        if (i == (Counter[g] / SampleSize))
                        { NeuronOutput[i].CalculateErrorOut(1); }
                        else { NeuronOutput[i].CalculateErrorOut(0); }
                        //EpsError += (float)Math.Pow(NeuronOutput[i].Error, 2) / 2f;
                        EpsSampleError += (float)Math.Pow(NeuronOutput[i].Error, 2) / 2f;
                    }
                    EpsEpochError += EpsSampleError;
                    countAccuracy[Counter[g]] = EpsSampleError;
                    if (EpsSampleError > epsilon)
                    { isAccurate = false; }

                    for (int i = 0; i < OutputNeuronSize; i++)
                    {
                        for (int j = 0; j < HiddenNeuronSize; j++)
                        {
                            NeuronOutput[i].ChangeWeight(Alpha, NeuronOutput[i].Error, NeuronOutput[i].Output, NeuronHidden[j].Output, j);
                        }
                    }
                    for (int i = 0; i < HiddenNeuronSize; i++)
                    {
                        NeuronHidden[i].Error = 0;
                        for (int j = 0; j < OutputNeuronSize; j++)
                        {
                            NeuronHidden[i].CalculateErrorHid(NeuronOutput[j].Error, NeuronOutput[j].Output, NeuronOutput[j].weight[i]);
                        }
                        for (int j = 0; j < N; j++)
                        {
                            NeuronHidden[i].ChangeWeight(Alpha, NeuronHidden[i].Error, NeuronHidden[i].Output, Sample[Counter[g]][j], j);
                        }
                    }
                    for (int i = g; i < Counter.Length - 1; i++)
                    {
                        Counter[i] = Counter[i + 1];
                    }
                    Array.Resize(ref Counter, Counter.Length - 1);
                }
                for (int i = 0; i < countAccuracy.GetLength(0); i++)
                {
                    string errString = countAccuracy[i] > epsilon ? " - ТУТ" : "";
                    epochs.WriteLine($"Точность({i}) - {countAccuracy[i]}{errString}");
                }
                epochWatch.Stop();
                epochs.WriteLine($"\nТочность эпохи - {EpsEpochError / Sample.GetLength(0)}");
                epochs.WriteLine($"Альфа = {Alpha.ToString("0.###############################")}");
                epochs.WriteLine($"Время: {string.Format("{0:0.000}", epochWatch.ElapsedMilliseconds / 1000f)} сек");
                epochs.WriteLine($"---Конец эпохи {Epoch}---");
                epochs.Close();
                //logs.Items.Add("");
                Alpha *= 0.99f;              
            } while (!isAccurate & (Epoch < nMax));
            stopWatch.Stop();
            EpsEpochError /= Sample.GetLength(0);
            lEpoch.Text = $"Эпохи = {Epoch} ({string.Format("{0:0.000}", stopWatch.ElapsedMilliseconds / 1000f)} сек)";
            lEpsilonError.Text = $"Эпсилон = {EpsEpochError}";
            //ShowWeightMap();
            //logs.Items.Clear();
            if (lGuess.Text != string.Empty)
                lGuess.Text = "Повторите";
            DirectoryInfo dirInfo = new DirectoryInfo($"Weights/{folder}");
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            for (int i = 0; i < OutputNeuronSize; i++)
            {
                NeuronOutput[i].SaveWeight();
            }
            for (int i = 0; i < HiddenNeuronSize; i++)
            {
                NeuronHidden[i].SaveWeight();
            }
            StreamWriter learningOutput = new StreamWriter($"Results/{cbSamples.Text}_A{startAlpha}_FC{FuncCoaf}_E{epsilon}_HNS{HiddenNeuronSize}_NMax{nudNMax.Value}/_Результаты.txt");
            learningOutput.WriteLine($"Время: {stopWatch.ElapsedMilliseconds / 1000f} сек.");
            learningOutput.WriteLine($"Эпохи: {Epoch}");
            learningOutput.WriteLine($"Ошибка на эпоху: {EpsEpochError}");
            learningOutput.WriteLine($"Альфа: {startAlpha}");
            learningOutput.WriteLine($"Коэффициент: {FuncCoaf}");
            learningOutput.WriteLine($"Эпсилон: {epsilon}");
            learningOutput.WriteLine($"Количество скрытых нейронов: {HiddenNeuronSize}");
            learningOutput.Close();
            StreamWriter time = new StreamWriter($"Weights/{folder}/time.txt");
            time.WriteLine(stopWatch.ElapsedMilliseconds);
            time.WriteLine(Epoch);
            time.WriteLine(EpsEpochError);
            time.WriteLine(startAlpha);
            time.WriteLine(FuncCoaf);
            time.WriteLine(epsilon);
            time.WriteLine(HiddenNeuronSize);
            lastHiddenSize = HiddenNeuronSize;
            time.Close();

        }
        private void bStartTesting_Click(object sender, EventArgs e)
        {
            if (lastHiddenSize != HiddenNeuronSize)
            {
                MessageBox.Show("Изменение размера скрытого слоя.");
                HiddenNeuronSize = lastHiddenSize;
                tHiddenNeuronSize.Text = HiddenNeuronSize.ToString();
                NeuronInitialize();
            }
            logs.Items.Clear();
            var errNeuron = new List<string>();
            int[][] Test = rbCenter.Checked ? TestCenter : rbScale.Checked ? TestScale : TestNormal;
            float Wrong = 0f; float Right = 0f;
            for (int k = 0; k < Test.GetLength(0); k++)
            {
                bool Mistake = false;
                float[] OutputsOfHidden = new float[HiddenNeuronSize];
                float FuncCoaf = (float)nudFuncCoef.Value;
                for (int i = 0; i < HiddenNeuronSize; i++)
                {
                    NeuronHidden[i].CalculateOutputHid(Test[k], FuncCoaf);
                    OutputsOfHidden[i] = NeuronHidden[i].Output;
                }
                for (int i = 0; i < OutputNeuronSize; i++)
                {
                    NeuronOutput[i].CalculateOutputOut(OutputsOfHidden, FuncCoaf);
                    if (
                        NeuronOutput[i].Output >= 0.8f && i != k / TestSize ||
                        NeuronOutput[i].Output <= 0.2f && i == k / TestSize ||
                        NeuronOutput[i].Output > 0.2f && NeuronOutput[i].Output < 0.8f
                       )
                    {
                        Mistake = true;
                        errNeuron.Add($"{NeuronNames[i]} : {NeuronOutput[i].Output}");
                    }
                }
                if (Mistake)
                {
                    Wrong++;
                    logs.Items.Add($"Изображение ({NeuronNames[k / TestSize]}-{k - (k / TestSize) * TestSize}) - не угадал.");
                    logs.Items.Add("Ошибка на:");
                    foreach (var error in errNeuron)
                    {
                        logs.Items.Add($"- {error}");
                    }
                    logs.Items.Add("");
                    errNeuron.Clear();
                }
                else { Right++; }
            }
            lRight.Text = $"Угадал = {Math.Round(Right / (Right + Wrong) * 100f, 2)}% ({Right}/{Right + Wrong})";
            StreamWriter learningOutput = File.AppendText($"Results/{cbSamples.Text}_A{startAlpha}_FC{FuncCoaf}_E{epsilon}_HNS{HiddenNeuronSize}_NMax{nudNMax.Value}/_Результаты.txt");
            learningOutput.WriteLine($"Процент угадываний: {Math.Round(Right / (Right + Wrong) * 100f, 2)} ({Right}/{Right + Wrong})");
            learningOutput.Close();
            StreamWriter testData = new StreamWriter($"Weights/{folder}/test_data.txt");
            testData.WriteLine(Math.Round(Right / (Right + Wrong) * 100f, 2));
            testData.WriteLine(Right);
            testData.WriteLine(Right + Wrong);
            testData.Close();
        }
        private void bTeachTest_Click(object sender, EventArgs e)
        {
            tHiddenNeuronSize.Text = $"{HiddenNeuronSize}";
            StartTraining();
            bStartTesting_Click(sender, e);
            if (!flag)
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show("Обучение завершено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        #endregion

        #region Эпсилон
        private void EpsilonChange()
        {
            EpsilonDegree = (int)nudEpsilon.Value;
            epsilon = (float)Math.Pow(10, EpsilonDegree);
            tEpsilon.Text = $"{epsilon}";
        }
        private void nudEpsilon_ValueChanged(object sender, EventArgs e)
        {
            EpsilonChange();
        }
        private void tEpsilon_TextChanged(object sender, EventArgs e)
        {
            try { epsilon = Convert.ToSingle(tEpsilon.Text); }
            catch 
            { 
                tEpsilon.Text = epsilon.ToString();
                MessageBox.Show("Введите число.", "Ошибка", MessageBoxButtons.OK); 
            }
        }
        #endregion

        #region Запуск
        private void SamplesLoad()
        {
            Clear();
            lRight.Text = "Угадал";
            logs.Items.Clear();
            NeuronNames = cbSamples.SelectedIndex == 0 ? 
                Program.NeuronNames1 : cbSamples.SelectedIndex == 1 ? Program.NeuronNames2 : Program.NeuronNames3;
            folder = cbSamples.SelectedIndex == 0 ? "Моя выборка (Знаки Зодиака)" :
                cbSamples.SelectedIndex == 1 ? "Выборка Алексея (Алхимические символы)" : "Выборка Тимофея (Цифры)";

            OutputNeuronSize = NeuronNames.Length;
            SampleSize = cbSamples.SelectedIndex == 1 ? 10 : 30;
            SampleNormal = new int[OutputNeuronSize * SampleSize][];
            SampleCenter = new int[OutputNeuronSize * SampleSize][];
            SampleScale = new int[OutputNeuronSize * SampleSize][];
            TestSize = cbSamples.SelectedIndex == 1 ? 5 : 10;
            TestNormal = new int[OutputNeuronSize * TestSize][];
            TestCenter = new int[OutputNeuronSize * TestSize][];
            TestScale = new int[OutputNeuronSize * TestSize][];

            if (File.Exists($"Weights/{folder}/time.txt"))
            {
                StreamReader load = new StreamReader($"Weights/{folder}/time.txt");
                int time = Convert.ToInt32(load.ReadLine());
                int epoch = Convert.ToInt32(load.ReadLine());
                string eps_error = load.ReadLine();
                decimal lastAlpha = Convert.ToDecimal(load.ReadLine());
                decimal lastCoaf = Convert.ToDecimal(load.ReadLine());
                string lastEpsilon = load.ReadLine();
                lastHiddenSize = Convert.ToInt32(load.ReadLine());

                lEpoch.Text = $"Эпохи = {epoch} ({string.Format("{0:0.000}", time / 1000f)} сек)";
                lEpsilonError.Text = $"Эпсилон = {eps_error}";
                nudAlpha.Value = lastAlpha;
                nudFuncCoef.Value = lastCoaf;
                tEpsilon.Text = lastEpsilon;
                logs.Items.Add($"Последнее количество скрытых нейронов: {lastHiddenSize}");
                HiddenNeuronSize = lastHiddenSize;
                tHiddenNeuronSize.Text = HiddenNeuronSize.ToString();
                load.Close();
            }
            NeuronInitialize();

            #region Загрузка изображений
            for (int n = 0; n < OutputNeuronSize; n++)
            {
                for (int j = 0; j < SampleSize; j++)
                {
                    SampleNormal[j + n * SampleSize] = new int[N];
                    SampleCenter[j + n * SampleSize] = new int[N];
                    SampleScale[j + n * SampleSize] = new int[N];
                    Bitmap bm;
                    if (cbSamples.SelectedIndex == 0) { bm = (Bitmap)Image.FromFile($"Sample/{NeuronNames[n]}-{j}.png"); }
                    else if (cbSamples.SelectedIndex == 1) { bm = (Bitmap)Image.FromFile($"Sample2/{NeuronNames[n]}_{j}.bmp"); }  //Чужая выборка
                    else { bm = (Bitmap)Image.FromFile($"Sample3/{NeuronNames[n]}-{j}.bmp"); }  //Чужая выборка
                    for (int k = 0; k < N; k++)
                    {
                        SampleNormal[j + n * SampleSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                    bm = Centering(bm);
                    for (int k = 0; k < N; k++)
                    {
                        SampleCenter[j + n * SampleSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                    bm = Scaling(bm);
                    for (int k = 0; k < N; k++)
                    {
                        SampleScale[j + n * SampleSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                }
                for (int j = 0; j < TestSize; j++)
                {
                    TestNormal[j + n * TestSize] = new int[N];
                    TestCenter[j + n * TestSize] = new int[N];
                    TestScale[j + n * TestSize] = new int[N];
                    Bitmap bm;
                    if (cbSamples.SelectedIndex == 0) { bm = (Bitmap)Image.FromFile($"Test/{NeuronNames[n]}-{j}.png"); }
                    else if (cbSamples.SelectedIndex == 1) { bm = (Bitmap)Image.FromFile($"Test2/{NeuronNames[n]}_{j}.bmp"); }  //Чужая выборка
                    else { bm = (Bitmap)Image.FromFile($"Test3/{NeuronNames[n]}-{j}.bmp"); }  //Чужая выборка
                    for (int k = 0; k < N; k++)
                    {
                        TestNormal[j + n * TestSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                    bm = Centering(bm);
                    for (int k = 0; k < N; k++)
                    {
                        TestCenter[j + n * TestSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                    bm = Scaling(bm);
                    for (int k = 0; k < N; k++)
                    {
                        TestScale[j + n * TestSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                }
            }
            #endregion

            SystemSounds.Asterisk.Play();
            MessageBox.Show("Загрузка завершена.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
        private void bSamples_Click(object sender, EventArgs e)
        {
            if (cbSamples.SelectedIndex == tempSemples)
            {
                MessageBox.Show("Вы пытаетесь загрузить уже загруженную выборку.", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                SamplesLoad();
                if (tempSemples == -1)
                {
                    nudNMax.Enabled = true;
                    bMegaTraining.Enabled = true;
                    bGive.Enabled = true;
                    bClear.Enabled = true;
                    bTeachTest.Enabled = true;
                    bStartTesting.Enabled = true;
                    bHiddenHeuronSizeChange.Enabled = true;
                    pbMain.Enabled = true;
                    tHiddenNeuronSize.Enabled = true;
                    tEpsilon.Enabled = true;
                    nudEpsilon.Enabled = true;
                    nudFuncCoef.Enabled = true;
                    nudAlpha.Enabled = true;
                }
                tempSemples = cbSamples.SelectedIndex;
            }
        }
        private void NeuronInitialize()
        {
            NeuronOutput = new Neuron[OutputNeuronSize];
            NeuronHidden = new Neuron[HiddenNeuronSize];
            for (int i = 0; i < OutputNeuronSize; i++)
            {
                NeuronOutput[i] = new Neuron(HiddenNeuronSize, i, Neuron.Type.output);
                NeuronOutput[i].LoadWeight();
            }

            for (int i = 0; i < HiddenNeuronSize; i++)
            {
                NeuronHidden[i] = new Neuron(N, i, Neuron.Type.hidden);
                NeuronHidden[i].LoadWeight();
            }
        }
        #endregion

        #region UI
        private void bHiddenHeuronSizeChange_Click(object sender, EventArgs e)
        {
            try 
            { 
                HiddenNeuronSize = Convert.ToInt32(tHiddenNeuronSize.Text);
                NeuronInitialize();
                bHiddenHeuronSizeChange.ForeColor = Color.Black;
            }
            catch
            {
                tHiddenNeuronSize.Text = HiddenNeuronSize.ToString();
                MessageBox.Show("Введите число.", "Ошибка", MessageBoxButtons.OK);
            }
        }
        private void bHelp_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form2();
            ifrm.Show();
        }
        private void MegaTraining(object sender, EventArgs e, decimal al, decimal fc, string eps, string HNS)
        {
            nudAlpha.Value = al;
            nudNMax.Value = 1000m;
            nudFuncCoef.Value = fc;
            tEpsilon.Text = eps;
            tHiddenNeuronSize.Text = HNS;
            bHiddenHeuronSizeChange_Click(sender, e);
            bTeachTest_Click(sender, e);
        }
        private void bMegaTraining_Click(object sender, EventArgs e)
        {
            flag = true;
            MegaTraining(sender, e, 0.3m, 1m, "0,01", "20"); //1
            MegaTraining(sender, e, 0.3m, 1m, "0,01", "100"); //2
            MegaTraining(sender, e, 0.3m, 1m, "0,01", "150"); //3
            MegaTraining(sender, e, 0.3m, 1m, "0,01", "200"); //4
            MegaTraining(sender, e, 0.3m, 1m, "0,001", "20"); //5
            MegaTraining(sender, e, 0.3m, 1m, "0,001", "100"); //6
            MegaTraining(sender, e, 0.3m, 1m, "0,001", "150"); //7
            MegaTraining(sender, e, 0.3m, 1m, "0,001", "200"); //8
            SystemSounds.Asterisk.Play();
            MessageBox.Show("Обучение завершено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            flag = false;
        }
        private void tHiddenHeuronSize_TextChanged(object sender, EventArgs e)
        {
            string HNS = Convert.ToString(HiddenNeuronSize);
            if (tHiddenNeuronSize.Text != HNS)
            {
                bHiddenHeuronSizeChange.ForeColor = Color.Red;
            }
            else
            {
                bHiddenHeuronSizeChange.ForeColor = Color.Black;
            }
        }
        private void bData_Click(object sender, EventArgs e)
        {
            NeuronNames = cbSamples.SelectedIndex == 0 ?
                Program.NeuronNames1 : cbSamples.SelectedIndex == 1 ? Program.NeuronNames2 : Program.NeuronNames3;
            folder = cbSamples.SelectedIndex == 0 ? "Моя выборка (Знаки Зодиака)" :
                cbSamples.SelectedIndex == 1 ? "Выборка Алексея (Алхимические символы)" : "Выборка Тимофея (Цифры)";
            string messageData;
            if (File.Exists($"Weights/{folder}/time.txt") & File.Exists($"Weights/{folder}/test_data.txt"))
            {
                StreamReader load = new StreamReader($"Weights/{folder}/time.txt");
                StreamReader testLoad = new StreamReader($"Weights/{folder}/test_data.txt");
                int time = Convert.ToInt32(load.ReadLine());
                int epoch = Convert.ToInt32(load.ReadLine());
                string eps_error = load.ReadLine();
                decimal lastAlpha = Convert.ToDecimal(load.ReadLine());
                decimal lastCoaf = Convert.ToDecimal(load.ReadLine());
                string lastEpsilon = load.ReadLine();
                lastHiddenSize = Convert.ToInt32(load.ReadLine());
                string percent = testLoad.ReadLine();
                string countRight = testLoad.ReadLine();
                string countAll = testLoad.ReadLine();

                messageData = $"Эпохи = {epoch} ({string.Format("{0:0.000}", time / 1000f)} сек)\n" +
                    $"Средняя ошибка = {eps_error}\n" +
                    $"Альфа = {lastAlpha}\n" +
                    $"Коэффициент = {lastCoaf}\n" +
                    $"Эпсилон = {lastEpsilon}\n" +
                    $"Скрытых нейронов = {lastHiddenSize}\n" +
                    $"Угадал = {percent}% ({countRight}/{countAll})";
                MessageBox.Show($"{messageData}", "Данные о последнем обучении.");
                load.Close();
                testLoad.Close();
            }
        }
        private void bResultsFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string resultFolderPath = Path.Combine(projectDirectory, "Results");
                Process.Start("explorer.exe", resultFolderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть папку: " + ex.Message);
            }
        }
        #endregion

        #region Масштабирование/Центрирование
        public Bitmap Scaling(Bitmap bm)
        {
            int height, width;
            int minX = 100, maxX = 0, minY = 100, maxY = 0;
            int[] imageArray = new int[10000];
            for (int i = 0; i < N; i++)
            {
                int curX = i % 100;
                int curY = i / 100;
                imageArray[i] = bm.GetPixel(curX, curY) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                if (imageArray[i] == 1)
                {
                    if (curX > maxX) maxX = curX;
                    if (curX < minX) minX = curX;
                    if (curY > maxY) maxY = curY;
                    if (curY < minY) minY = curY;
                }
            }
            width = maxX - minX + 1;
            height = maxY - minY + 1;

            if (!(width < 0 || height < 0))
            {
                Bitmap bmp = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int InputVector = 0; InputVector < width; InputVector++)
                    {
                        int index = (y + minY) * 100 + (InputVector + minX);
                        if (imageArray[index] == 1)
                            bmp.SetPixel(InputVector, y, Color.FromArgb(255, 0, 0, 0));
                        else
                            bmp.SetPixel(InputVector, y, Color.FromArgb(0, 0, 0, 0));
                    }
                }
                Bitmap centeredBmp = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(centeredBmp);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.Clear(Color.FromArgb(0, 0, 0, 0));
                g.DrawImage(bmp, 0, 0, 100, 100);
                return Centering(centeredBmp);
            }
            return bm;
        }

        public Bitmap Centering(Bitmap bm)
        {
            int height, width;
            int minX = 100, maxX = 0, minY = 100, maxY = 0;
            int[] imageArray = new int[10000];
            for (int i = 0; i < N; i++)
            {
                int curX = i % 100;
                int curY = i / 100;
                imageArray[i] = bm.GetPixel(curX, curY) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                if (imageArray[i] == 1)
                {
                    if (curX > maxX) maxX = curX;
                    if (curX < minX) minX = curX;
                    if (curY > maxY) maxY = curY;
                    if (curY < minY) minY = curY;
                }
            }
            width = maxX - minX + 1;
            height = maxY - minY + 1;

            int offsetX = (100 - width) / 2;
            int offsetY = (100 - height) / 2;
            if (!(width < 0 || height < 0))
            {
                Bitmap bmp = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int InputVector = 0; InputVector < width; InputVector++)
                    {
                        int index = (y + minY) * 100 + (InputVector + minX);
                        if (imageArray[index] == 1)
                            bmp.SetPixel(InputVector, y, Color.FromArgb(255, 0, 0, 0));
                        else
                            bmp.SetPixel(InputVector, y, Color.FromArgb(0, 0, 0, 0));
                    }
                }
                Bitmap centeredBmp = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(centeredBmp);
                g.Clear(Color.FromArgb(0, 0, 0, 0));
                g.DrawImage(bmp, offsetX, offsetY);
                return centeredBmp;
            }
            return bm;
        }
        #endregion
    }
}
