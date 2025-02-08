using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nero_Network
{
    internal static class Program
    {
        public static string[] NeuronNames1 = { "Овен", "Телец", "Близнецы", "Рак",
                                               "Лев", "Дева", "Весы", "Скорпион",
                                               "Стрелец", "Козерог", "Водолей", "Рыбы"};
        public static string[] NeuronNames2 = { "Огонь", "Воздух", "Вода", "Земля",      //
                                               "Смерть", "Жизнь", "Свинец", "Олово",    //Чужая выборка
                                               "Железо", "Медь", "Серебро", "Золото"};  //
        public static string[] NeuronNames3 = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };  //Чужая выборка
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());            
        }
    }
}
