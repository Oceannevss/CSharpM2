using OceCLIm2;
namespace InterfaceM2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        OceCLIm2.Model.OpenAI openAI = new OceCLIm2.Model.OpenAI();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void CorrectText(object sender, EventArgs e) { 

            var text = CorrectionEditor.Text;
            var res = await openAI.CorrectSentences(text);
            ResponseCorrection.Text = $"Correction : {res}";

            SemanticScreenReader.Announce(ResponseCorrection.Text);
        }

        private async void TranslateText(object sender, EventArgs e)
        {
            
            var text = TranslateEditor.Text;
            var res = await openAI.TradSentences(text);
            ResponseTranslation.Text = $"Traduction : {res}";

            SemanticScreenReader.Announce(ResponseTranslation.Text);
        }
    }

}
