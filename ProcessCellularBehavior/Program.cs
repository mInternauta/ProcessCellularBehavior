using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessCellularBehavior
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // -
            string CELULA_EXE = System.AppDomain.CurrentDomain.FriendlyName;
            Random rnd = new Random();

            // -
            // % de Chande desta Célula Morrer
            float ChanceDeMorrer = 45.5F;
                       
            // -
            // % de Chance desta Célula evoluir (Nova SPECIE)
            float ChanceDeEvoluir = 15.2F;

            // -
            // Cinco de Vida em Segundas da Célula
            float CINCO_COGNITIVO = 20;

            // -
            int SPECIE = 0;
            long SUBJECT = 0;

            // -
            // Coleta Informações se a Celula Atual já é outra espécie
            if(args != null && args.Length > 0)
            {
                SPECIE = int.Parse(args[0]);
                SUBJECT = long.Parse(args[1]);
            }

            // -
            // LOG 
            EscreverLog(SUBJECT, SPECIE, "(0.0) Apareceu");

            // - 
            // Se for o PRIMEIRO Individou da Primeira Espécie não Morre
            if (SUBJECT == 0 && SPECIE == 0)
                ChanceDeMorrer = 0;

            // Se for os PRIMEIROS 5 Individous da Primeira Espécie a Chance de Morrer é Baixa
            if (SUBJECT > 0 && SUBJECT <= 5 && SPECIE == 0)
                ChanceDeMorrer = 10;

            // - Se for uma espécia nova ( > 0), então diminue a chance de morrer.
            if (SPECIE > 0)
            {
                // -
                float somaChanceMorrer = 0.021f * SPECIE;
                ChanceDeMorrer += somaChanceMorrer;

                // - Aumenta o Processo Cognitivo
                float dimCicloVida = 0.012f * SPECIE;
                CINCO_COGNITIVO -= dimCicloVida;
            }

            // Executa o processo de uma Célula     
            int CICLOS = 0;
            while (true)
            {
                // -
                Thread.Sleep((int)CINCO_COGNITIVO * 1000);

                // - Verifica se ela vai morrer ou não
                float V_VIDA = (float)rnd.NextDouble(0, 100);

                // - 
                if(V_VIDA <= ChanceDeMorrer)
                {
                    // LOG 
                    EscreverLog(SUBJECT, SPECIE, "(~.~) Morreu");

                    // Celula Morreu
                    Application.Exit();
                }
                else
                {
                    // Próxima Espécia
                    int PRX_SPECIE = SPECIE;
                    long NXT_SUBJECT = SUBJECT + 1;

                    float V_EVOLUCAO = (float)rnd.NextDouble(0, 100);
                    if(V_EVOLUCAO <= ChanceDeEvoluir)
                    {
                        // Celula Evoluiu 
                        PRX_SPECIE++;
                    }

                    // 
                    Process.Start(CELULA_EXE, PRX_SPECIE.ToString() + " " + NXT_SUBJECT.ToString());

                    // LOG 
                    EscreverLog(SUBJECT, SPECIE, "Se reproduziu para " + PRX_SPECIE);
                }

                CICLOS++;

                if(CICLOS > 15)
                {
                    // a Celula está velha e tem altas chances de morrer
                    ChanceDeMorrer = 75;
                }
            }
        }

        private static void EscreverLog(long sUBJECT, int sPECIE, string msg)
        {
            string arqLog = Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName) + ".log";

            using (StreamWriter wr = new StreamWriter(File.Open(arqLog,
                FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                wr.WriteLine("[SUBJECT:{0}] [SPECIE:{1}] {2}", sUBJECT, sPECIE, msg);
            }
        }

        public static double NextDouble(this Random random, double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
