using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using DelastelleCipher.Crypter;
using DelastelleCipher.Crypter.Cyphers;
using DelastelleCipher.Crypter.Factory;
using DelastelleCipher.Crypter.Utils;

namespace DelastelleCipher.ViewModels
{
    public class CypherViewModel : Screen
    {
        private ICypher crypter;
        public CypherViewModel()
        {
            CypherType = Enum.GetValues(typeof(DelastelleCypherType)).Cast<DelastelleCypherType>().ToList();
            MatrixHeaders = new string[] {"1", "2", "3", "4", "5"};
            MatrixVisible = Visibility.Hidden;
        }

        private string _key;
 
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private string _textToEncodeDecode;

        public string TextToEncodeDecode
        {
            get { return _textToEncodeDecode; }
            set { _textToEncodeDecode = value.ToUpperInvariant(); }
        }

        private string _result;

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                NotifyOfPropertyChange(() => Result);
            }
        }

        private Visibility _matrixVisible;

        public Visibility MatrixVisible
        {
            get { return _matrixVisible; }
            set
            {
                _matrixVisible = value;
                NotifyOfPropertyChange(() => MatrixVisible);
            }
        }



        private DelastelleCypherType _selectedCypherType;

        public DelastelleCypherType SelectedCypherType
        {
            get { return _selectedCypherType; }
            set { Set(ref _selectedCypherType, value); }
        }

        public IReadOnlyList<DelastelleCypherType> CypherType { get; }

        public string[] MatrixHeaders { get; }

        private char[,] _matrixValues;

        public char[,] MatrixValues
        {
            get { return _matrixValues; }
            set
            {
                _matrixValues = value;
                NotifyOfPropertyChange(() => MatrixValues);
            }
        }



        public void Encode()
        {
            crypter = DelastellaCypherFactory.Create(Key.UnifyKey(), SelectedCypherType);
            MatrixValues = crypter.MatrixGenerator.PobliusMatrix;
            Result = crypter.Encode(TextToEncodeDecode);
            MatrixVisible = Visibility.Visible;
        }

        public void Decode()
        {
            Result = crypter.Decode(TextToEncodeDecode);
        }
    }
}
