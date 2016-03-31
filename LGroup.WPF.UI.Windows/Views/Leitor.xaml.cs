using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

// DESCEMOS PARA A MEMORIA O SPEAK
using System.Speech.Synthesis;
namespace LGroup.WPF.UI.Windows.Views
{
    /// <summary>
    /// Interaction logic for Leitor.xaml
    /// </summary>
    public partial class Leitor : Window
    {
        public Leitor()
        {
            InitializeComponent();
        }

        public void Falar(string texto_, int volume_, int velocidade_)
        {
            // ARMAZENAMOS NA VARIAVEL O SINTETIZADOR DE VOZ
            var voz = new SpeechSynthesizer();

            // PARAMETRIZAR A VOZ DO SISTEMA QUE IREMOS UTILIZAR PARA O TEXTO
            PromptBuilder builder = new PromptBuilder();

            //INDICAMOS A VOZ QUE IREMOS UTILIZAR
            builder.StartVoice("ScanSoft Raquel_Full_22Hz");

                //ADICIONAMOS O TEXTO
                builder.AppendText(texto_);

            // FINALIZAR
            builder.EndVoice();

            //ADICIONAMOS OS PARAMETROS DE VOZ
            voz.SetOutputToDefaultAudioDevice();

            // VELOCIDADE
            voz.Rate = velocidade_;

            // VOLUME
            voz.Volume = volume_;

            //FINALIZAMOS
            voz.Speak(builder);

        }

        private void buttonFalar_Click(object sender, RoutedEventArgs e)
        {
            Falar(textFalar.Text, 100, -4);
        }

        private void textFalar_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var textoFala = textFalar.SelectedText;
            Falar(textoFala, 100, 0);
        }
    }
}
