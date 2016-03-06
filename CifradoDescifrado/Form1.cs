using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;

namespace CifradoDescifrado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Paso a Bytes la clave
            string textoCifrarString = textDescifrado.Text;
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(textoCifrarString);
         //   byte[] dataToEncrypt = numStrToPackedByteArray(textoCifrarString);

            //Paso a Bytes la clave
            string keyString = textKey.Text;
            byte[] key = hexStrToPackedByteArray(keyString);
           
            //byte[] key = Encoding.UTF8.GetBytes(keyString);

            //Paso a Bytes el IV
            String ivString = textIV.Text;
            //byte[] iv = Encoding.UTF8.GetBytes(ivString);
            byte[] iv = hexStrToPackedByteArray(ivString);


            //Extraccion de modos de encadenamiento
            String tipoModoEncadenamiento = comboEncadenamiento.SelectedItem.ToString();

            //Extraccion de modo de padding
            String tipoPadding = comboPadding.SelectedItem.ToString();

            //Extraccion del tipo de Cifrado
            String tipoCifrado = comboTipoCifrado.SelectedItem.ToString();

            switch (tipoCifrado)
            {
                case "3DES":
                    cifrado3DES(tipoModoEncadenamiento, tipoPadding, dataToEncrypt, key, iv);
                    break;

                case "DES":
                    cifradoDES(tipoModoEncadenamiento, tipoPadding, dataToEncrypt, key, iv);
                    break;
            }


        }

        private void buttonDescifrado_Click(object sender, EventArgs e)
        {
            //Paso a Bytes la clave
            String textoDescifrarString = textCifrado.Text;
            
           // byte[] dataToDecrypt = numStrToPackedByteArray(textoDescifrarString);
            byte[] dataToDecrypt = hexStrToPackedByteArray(textoDescifrarString);
            // byte[] dataToDecrypt = Convert.FromBase64String(textoDescifrarString);
            // byte[] dataToDecrypt = Encoding.UTF8.GetBytes(textoDescifrarString);

            //Paso a Bytes la clave
            String keyString = textKey.Text;
            //byte[] key = Encoding.UTF8.GetBytes(keyString);
            byte[] key = hexStrToPackedByteArray(keyString);

            //Paso a Bytes el IV
            String ivString = textIV.Text;
            //            byte[] iv = Encoding.UTF8.GetBytes(ivString);
            byte[] iv = hexStrToPackedByteArray(ivString);


            //Extraccion de modos de encadenamiento
            String tipoModoEncadenamiento = comboEncadenamiento.SelectedItem.ToString();

            //Extraccion de modo de padding
            String tipoPadding = comboPadding.SelectedItem.ToString();

            //Extraccion del tipo de Cifrado
            String tipoCifrado = comboTipoCifrado.SelectedItem.ToString();



            switch (tipoCifrado)
            {
                case "3DES":
                    descifrado3DES(tipoModoEncadenamiento, tipoPadding, dataToDecrypt, key, iv);
                    break;

                case "DES":
                    descifradoDES(tipoModoEncadenamiento, tipoPadding, dataToDecrypt, key, iv);
                    break;
            }

        }


        private void descifrado3DES(String tipoModoEncadenamiento, string tipoPadding, byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var des = new TripleDESCryptoServiceProvider())
            {
                //Se define el padding y las claves
                des.Key = key;
                des.IV = iv;

                //Cuando mejore el código lo meteremos como un switch
                if (tipoModoEncadenamiento.Equals("CBC"))
                {
                    des.Mode = CipherMode.CBC;
                }
                else
                {
                    des.Mode = CipherMode.ECB;
                }


                switch (tipoPadding)
                {

                    case "PKCS7":
                        des.Padding = PaddingMode.PKCS7;
                        break;

                    case "Zeros":
                        des.Padding = PaddingMode.Zeros;
                        break;

                    case "None":
                        des.Padding = PaddingMode.None;
                        break;

                    case "ANSIX923":
                        des.Padding = PaddingMode.ANSIX923;
                        break;

                    case "ISO10126":
                        des.Padding = PaddingMode.ISO10126;
                        break;

                }


                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    //String cadena = Encoding.UTF8.GetString(memoryStream.ToArray());
                    String cadena = ConvertHex(packedByteArrayToHexStr(memoryStream.ToArray(), 0, memoryStream.ToArray().Length));
                    Console.WriteLine(cadena);
                    Console.WriteLine(Encoding.UTF8.GetString(memoryStream.ToArray()));
                    Console.WriteLine(packedByteArrayToHexStr(memoryStream.ToArray(), 0, memoryStream.ToArray().Length));
                    textDescifrado.Text = cadena;

                }
            }
        }

        private void descifradoDES(String tipoModoEncadenamiento, string tipoPadding, byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                //Se define el padding y las claves
                des.Key = key;
                des.IV = iv;

                //Cuando mejore el código lo meteremos como un switch
                if (tipoModoEncadenamiento.Equals("CBC"))
                {
                    des.Mode = CipherMode.CBC;
                }
                else
                {
                    des.Mode = CipherMode.ECB;
                }


                switch (tipoPadding)
                {

                    case "PKCS7":
                        des.Padding = PaddingMode.PKCS7;
                        break;

                    case "Zeros":
                        des.Padding = PaddingMode.Zeros;
                        break;

                    case "None":
                        des.Padding = PaddingMode.None;
                        break;

                    case "ANSIX923":
                        des.Padding = PaddingMode.ANSIX923;
                        break;

                    case "ISO10126":
                        des.Padding = PaddingMode.ISO10126;
                        break;

                }


                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    //cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    //cryptoStream.FlushFinalBlock();

                    String cadena = ConvertHex(packedByteArrayToHexStr(memoryStream.ToArray(), 0, memoryStream.ToArray().Length));
                    textDescifrado.Text = cadena;
                }
            }
        }

        // Cifrados
        private void cifrado3DES(String tipoModoEncadenamiento, string tipoPadding, byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var des = new TripleDESCryptoServiceProvider())
            {
                //Se define el padding y las claves
                des.Key = key;
                des.IV = iv;

                //Cuando mejore el código lo meteremos como un switch
                if (tipoModoEncadenamiento.Equals("CBC"))
                {
                    des.Mode = CipherMode.CBC;
                }
                else
                {
                    des.Mode = CipherMode.ECB;
                }


                switch (tipoPadding)
                {

                    case "PKCS7":
                        des.Padding = PaddingMode.PKCS7;
                        break;

                    case "Zeros":
                        des.Padding = PaddingMode.Zeros;
                        break;

                    case "None":
                        des.Padding = PaddingMode.None;
                        break;

                    case "ANSIX923":
                        des.Padding = PaddingMode.ANSIX923;
                        break;

                    case "ISO10126":
                        des.Padding = PaddingMode.ISO10126;
                        break;

                }


                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();
              
                    String cadena = packedByteArrayToHexStr(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
                    textCifrado.Text = cadena;


                }
            }
        }

        private void cifradoDES(String tipoModoEncadenamiento, string tipoPadding, byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                //Se define el padding y las claves
                des.Key = key;
                des.IV = iv;

                //Cuando mejore el código lo meteremos como un switch
                if (tipoModoEncadenamiento.Equals("CBC"))
                {
                    des.Mode = CipherMode.CBC;
                }
                else
                {
                    des.Mode = CipherMode.ECB;
                }


                switch (tipoPadding)
                {

                    case "PKCS7":
                        des.Padding = PaddingMode.PKCS7;
                        break;

                    case "Zeros":
                        des.Padding = PaddingMode.Zeros;
                        break;

                    case "None":
                        des.Padding = PaddingMode.None;
                        break;

                    case "ANSIX923":
                        des.Padding = PaddingMode.ANSIX923;
                        break;

                    case "ISO10126":
                        des.Padding = PaddingMode.ISO10126;
                        break;

                }


                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();


                    //     String cadena = Convert.ToBase64String(memoryStream.ToArray());
                    //     textCifrado.Text = cadena;
                    String cadena = packedByteArrayToHexStr(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
                    textCifrado.Text = cadena;

                }
            }
        }

        /**
         * Este método convierte un String que debe contener únicamente dígitos numéricos,
         * a un byte[] empaquetado a partir de un offset determinado.
         * 
         * un byte [] empaquetado tiene dos dígitos del String por byte
         * 
         * @param   str     Cadena de texto a convertir
         * @param   ba      Array de bytes donde guardar el resultado
         * @param   offset  offset a partir del cual se guarda el resultado
         * 
         * @throws  IllegalArgumentException    Alguno de los argumentos no es válido
         */
        public static byte[] hexStrToPackedByteArray(String str)
        {

            // Validaciones iniciales
            if (str == null)
            {
                MessageBox.Show("hexStrToPackedByteArray() - str es null");

            }

            if (str.Length == 0)
            {
                MessageBox.Show("hexStrToPackedByteArray() - str tiene longitud cero");

            }

            if ((str.Length & 0x0001) == 0x0001)
            {
                MessageBox.Show("hexStrToPackedByteArray() - str tiene longitud impar");

            }

            // Creamos un array con la mitad de longitud que el String 
            byte[] temporal = new byte[str.Length >> 1];

            int j = 0;
            int highNibble = 1;
            for (int i = 0; i < str.Length; i++)
            {
                try {
                    byte digit;

                    if ((str[i] >= '0') && (str[i] <= '9'))
                    {
                        digit = (byte)(str[i] - '0');
                    }
                    else if ((str[i] >= 'A') && (str[i] <= 'F'))
                    {
                        digit = (byte)(str[i] - 'A' + 10);
                    }
                    else if ((str[i] >= 'a') && (str[i] <= 'f'))
                    {
                        digit = (byte)(str[i] - 'a' + 10);
                    }
                    else {
                        //Da problemas pq no está controlada la excepcion
                        throw new System.Exception();
                    }

                    // Asignamos el valor del caracter en su lugar correspondiente
                    if (highNibble == 1)
                    {
                        temporal[j] = (byte)(digit << 4);
                        highNibble = 0;
                    }
                    else {
                        temporal[j] |= (byte)(digit & 0x00FF);
                        highNibble = 1;
                        j++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("hexStrToPackedByteArray() - carácter inválido en el string - " + str + " " + ex.Message);

                }
            }

            return temporal;
        }

        /**
         * Este método convierte un byte[] empaquetado a un String
         * con dígitos hexadecimales.
         * 
         * Un byte [] empaquetado tiene dos dígitos del String por byte
         * 
         * @param   ba      byte[] a convertir
         * @param   offset  offset a partir del que comienza la conversión
         * @param   size    número de bytes a convertir
         * 
         * @throws  IllegalArgumentException    Alguno de los argumentos no es válido
         */
        public static String packedByteArrayToHexStr(byte[] ba, int offset, int size)
        {

            StringBuilder stringBuffer = new StringBuilder();
            stringBuffer = null;

            String message = null;

            try {

                // Validaciones iniciales
                if (ba == null)
                {
                    message = "packedByteArrayToHexStr() - ba es null";
                    throw new System.Exception();
                }

                if (offset < 0)
                {
                    message = "packedByteArrayToHexStr() - offset es negativo";
                    throw new System.Exception();
                }

                if (size <= 0)
                {
                    message = "packedByteArrayToHexStr() - size es negativo o cero";
                    throw new System.Exception();
                }

                if (offset > (ba.Length - size))
                {
                    message = "packedByteArrayToHexStr() - offset más size mayor que length";
                    throw new System.Exception();
                }

                stringBuffer = new StringBuilder(size);

                // Se recorre el byte[] conviertiendo cada byte
                // desde offset hasta offset + size
                for (int i = offset; i < (offset + size); i++)
                {

                    char digit;

                    // Nibble más significativo
                    digit = (char)((ba[i] >> 4) & 0x0F);
                    if (digit > 9)
                    {
                        digit = (char)(digit + 'A' - 10);
                    }
                    else {
                        digit = (char)(digit + '0');
                    }
                    stringBuffer.Append(digit);

                    // Nibble menos significativo
                    digit = (char)(ba[i] & 0x0F);
                    if (digit > 9)
                    {
                        digit = (char)(digit + 'A' - 10);
                    }
                    else {
                        digit = (char)(digit + '0');
                    }
                    stringBuffer.Append(digit);

                }

            } catch (Exception ex)
            {
                MessageBox.Show("packedByteArrayToHexStr() - " + ex.Message);
            }

            return stringBuffer.ToString();
        }


        public static byte[] numStrToPackedByteArray(string str)
        {
            try{

                string message;
                byte[] temporal = null;

            // Validaciones iniciales
            if (str == null)
            {
                message = "numStrToPackedByteArray() - str es null";
                throw new System.Exception();
                }

            if (str.Length == 0)
            {
                message = "numStrToPackedByteArray() - str tiene longitud cero";
                throw new System.Exception();
                }

            if ((str.Length & 0x0001) == 0x0001)
            {
                message = "numStrToPackedByteArray() - str tiene longitud impar";
                throw new System.Exception();
            }

            // Creamos un array con la mitad de longitud que el String 
            temporal = new byte[str.Length >> 1];

            int j = 0;
            int highNibble = 1;
            for (int i = 0; i < str.Length; i++)
            {

                if ((str[i] < '0') || (str[i] > '9'))
                {
                    message = "numStrToPackedByteArray() - carácter inválido en el string - " + str ;
                        throw new System.Exception();
                }

                // Asignamos el valor del caracter en su lugar correspondiente
                if (highNibble == 1)
                {
                    temporal[j] = (byte)((str[i] - '0') << 4);
                    highNibble = 0;
                }
                else {
                    temporal[j] |= (byte)((str[i] - '0') & 0x00FF);
                    highNibble = 1;
                    j++;
                }
                    
            }
                return temporal;
            }
            catch( Exception ex) {
                MessageBox.Show("numStrToPackedByteArray() - " + ex.Message);
                return null;
             
            }

           
        }

        public static string ByteArrayToHexString(byte[] Bytes)
        {
            StringBuilder Result = new StringBuilder(Bytes.Length * 2);
            string HexAlphabet = "0123456789ABCDEF";

            foreach (byte B in Bytes)
            {
                Result.Append(HexAlphabet[(int)(B >> 4)]);
                Result.Append(HexAlphabet[(int)(B & 0xF)]);
            }

            return Result.ToString();
        }

        public static byte[] HexStringToByteArray(string Hex)
        {
            byte[] Bytes = new byte[Hex.Length / 2];
            int[] HexValue = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05,
       0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
       0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            for (int x = 0, i = 0; i < Hex.Length; i += 2, x += 1)
            {
                Bytes[x] = (byte)(HexValue[Char.ToUpper(Hex[i + 0]) - '0'] << 4 |
                                  HexValue[Char.ToUpper(Hex[i + 1]) - '0']);
            }

            return Bytes;
        }

        public static string ConvertHex(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }

        private static byte[] HashSHA256(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }

        private static byte[] HashSHA512(byte[] key, byte[] message)
        {
            var hash = new HMACSHA512(key);
            return hash.ComputeHash(message);
        }

        private static byte[] MacRetail(byte[] key, byte[] dataToEncrypt)
        {
            byte[] result = null;
            
            byte[] key1 = new byte[8];
            Array.Copy(key, 0, key1, 0, 8);
            byte[] key2 = new byte[8];
            Array.Copy(key, 8, key2, 0, 8);

            DES des1 = DES.Create();
            des1.Key = key1;
            des1.Mode = CipherMode.CBC;
            des1.Padding = PaddingMode.None;
            des1.IV = new byte[8];

            DES des2 = DES.Create();
            des2.Key = key2;
            des2.Mode = CipherMode.CBC;
            des2.Padding = PaddingMode.None;
            des2.IV = new byte[8];

            // MAC Algorithm 3
            byte[] intermediate = des1.CreateEncryptor().TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);

            // Output Transformation 3
            byte[] intermediate2 = des2.CreateDecryptor().TransformFinalBlock(intermediate, intermediate.Length - 8, 8);

            result = des1.CreateEncryptor().TransformFinalBlock(intermediate2, 0, 8);

            return result;
        }

        private void textKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboTipoCifrado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textCifrado_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboPadding_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void buttonUuid_Click(object sender, EventArgs e)
        {
          
            textUuid.Text = Guid.NewGuid().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            //Capturar excepcion
            int value;
            bool resultado = int.TryParse(comboLongKey.SelectedItem.ToString(),out value);
       
            byte[] key = new byte[value]; // For a 192-bit key = 24 bytes
            rng.GetBytes(key);

            textGenerateKey.Text=ByteArrayToHexString(key);
                        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Paso a Bytes la clave
            string textoCalcularMAc = textBoxTextMAC.Text;
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(textoCalcularMAc);


            //Paso a Bytes la clave
            string keyString = textKeyMAC.Text;
            byte[] key = hexStrToPackedByteArray(keyString);
            byte[] mac = null;

            String tipoMac = comboBoxMAC.SelectedItem.ToString();

            switch (tipoMac)
            {
                case "SHA256":
                    mac = HashSHA256(key, dataToEncrypt);
                    break;

                case "SHA512":
                    mac = HashSHA512(key, dataToEncrypt);
                    break;
                case "MAC X9.19":
                    mac = MacRetail(key, dataToEncrypt);
                    break;
            }

            string cadena = packedByteArrayToHexStr(mac, 0, mac.Length);

            textBoxMAC.Text = cadena;


        }

        private void comboBoxMAC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
