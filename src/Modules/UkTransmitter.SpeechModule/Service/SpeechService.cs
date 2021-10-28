using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.SpeechModule.Service
{

    /// <summary>
    /// Служба по работе с преобразователями речи
    /// </summary>
    public sealed class SpeechService : ISpeechService
    {
        #region Private Methods

        #endregion

        #region Public Methods

        #endregion

        #region Constructor

        #endregion

        #region Public API

        #endregion

        #region Private Methods

        #endregion

        //public static WaveInEvent waveSource = null;
        //public static WaveFileWriter waveFile = null;
        //public static Model model = new Model(@"D:\WavFromMicrophone\LearningModel\vosk-model-small-ru-0.15");

        //public void Main()
        //{


        //    //var pathToWav = GenerateFileName();
        //    //WriteSpeechToFile(pathToWav);
        //    //RecognizeWav(pathToWav);

        //    UserCredential credential;
        //    using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
        //    {
        //        credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
        //            GoogleClientSecrets.Load(stream).Secrets,
        //            new[] { "https://www.googleapis.com/auth/cloud-platform" },
        //            "User", CancellationToken.None, new FileDataStore("GmailApi")
        //            );
        //    }

        //    //Channel channel = new Channel(
        //    //    SpeechClient.DefaultEndpoint, 443, credential.ToChannelCredentials()
        //    //    );

        //    var speech = new SpeechClientBuilder()
        //    {
        //        ChannelCredentials = credential.ToChannelCredentials()
        //    }.Build();

        //    var response = speech.Recognize(new RecognitionConfig()
        //    {
        //        Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
        //        SampleRateHertz = 44100,
        //        LanguageCode = "ru",

        //    },
        //    RecognitionAudio.FromFile(@"D:\WavFromMicrophone\Test10075.wav")
        //    );


        //    foreach (var result in response.Results)
        //    {
        //        foreach (var alternative in result.Alternatives)
        //        {
        //            Console.WriteLine(alternative.Transcript);
        //        }
        //    }

        //}

        //static string GenerateFileName()
        //{
        //    Random rand = new Random();
        //    return $"D:\\WavFromMicrophone\\Test{rand.Next(1, 30000)}.wav";
        //}

        //static void WriteSpeechToFile(string pathToWavFile)
        //{

        //    waveSource = new WaveInEvent();
        //    waveSource.WaveFormat = new WaveFormat(44100, 1);

        //    waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
        //    waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

        //    waveFile = new WaveFileWriter(pathToWavFile, waveSource.WaveFormat);


        //    Console.WriteLine("Для начала записи нажмите R");
        //    var key = Console.ReadKey();

        //    if (key.Key == ConsoleKey.R)
        //    {
        //        waveSource.StartRecording();
        //    }

        //    Console.WriteLine("Для прекращения записи нажмите S");
        //    key = Console.ReadKey();

        //    if (key.Key == ConsoleKey.S)
        //    {
        //        waveSource.StopRecording();
        //    }
        //}

        //static void RecognizeWav(string pathToFile)
        //{
        //    // Demo byte buffer
        //    VoskRecognizer rec = new VoskRecognizer(model, 44100.0f);
        //    rec.SetMaxAlternatives(0);
        //    rec.SetWords(true);
        //    using (Stream source = File.OpenRead(pathToFile))
        //    {
        //        byte[] buffer = new byte[4096];
        //        int bytesRead;
        //        while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
        //        {
        //            if (rec.AcceptWaveform(buffer, bytesRead))
        //            {
        //                Console.WriteLine(rec.Result());
        //            }
        //            else
        //            {
        //                Console.WriteLine(rec.PartialResult());
        //            }
        //        }
        //    }

        //    Console.WriteLine(rec.FinalResult());
        //}

        //static void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        //{
        //    if (waveFile != null)
        //    {
        //        waveFile.Write(e.Buffer, 0, e.BytesRecorded);
        //        waveFile.Flush();
        //    }
        //}

        //static void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        //{
        //    if (waveSource != null)
        //    {
        //        waveSource.Dispose();
        //        waveSource = null;
        //    }

        //    if (waveFile != null)
        //    {
        //        waveFile.Dispose();
        //        waveFile = null;
        //    }
        //}

    }

}
