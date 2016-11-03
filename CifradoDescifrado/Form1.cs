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
        public string myLog;
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
            
            byte[] dataToEncrypt = null;
            string textoCifrarString = textDescifrado.Text;

            if (checkHexadecimal.ThreeState == false){
                //Paso a Bytes del texto
                dataToEncrypt = Encoding.UTF8.GetBytes(textoCifrarString);
            }
            else{
                //Paso a Bytes de la cadena como hexadecimal
                dataToEncrypt = hexStrToPackedByteArray(textoCifrarString);
            }

           

            myLog = "Texto a cifrar: " + textoCifrarString + "\r\n";



            //Paso a Bytes la clave
            string keyString = textKey.Text;
            byte[] key = hexStrToPackedByteArray(keyString);

            myLog = myLog + "Clave usada para cifrar : " + keyString + "\r\n";

            Console.Write(myLog); 
           
            //Paso a Bytes el IV
            String ivString = textIV.Text;
            //byte[] iv = Encoding.UTF8.GetBytes(ivString);
            byte[] iv = hexStrToPackedByteArray(ivString);
            myLog = myLog + "IV : " + ivString + "\r\n";

            //Extraccion de modos de encadenamiento
            String tipoModoEncadenamiento = comboEncadenamiento.SelectedItem.ToString();

            //Extraccion de modo de padding
            String tipoPadding = comboPadding.SelectedItem.ToString();

            //Extraccion del tipo de Cifrado
            String tipoCifrado = comboTipoCifrado.SelectedItem.ToString();

            myLog = myLog + "Modo encadenamiento : " + tipoModoEncadenamiento + "," + "Tipo de Padding: " + tipoPadding + "," + "Modo de cifrado: " + tipoCifrado + "\r\n";

            switch (tipoCifrado)
            {
                case "3DES":
                    cifrado3DES(tipoModoEncadenamiento, tipoPadding, dataToEncrypt, key, iv);
                    break;

                case "DES":
                    cifradoDES(tipoModoEncadenamiento, tipoPadding, dataToEncrypt, key, iv);
                    break;
            }

            if (checkStepByStep.ThreeState == true)
            {
                StepByStep log = new StepByStep();
                log.Show();
                log.logFrame.Text = myLog;
            }
            


        }

        private void buttonDescifrado_Click(object sender, EventArgs e)
        {
            //Paso a Bytes la clave
            String textoDescifrarString = textCifrado.Text;

            byte[] dataToDecrypt = hexStrToPackedByteArray(textoDescifrarString);

            //Paso a Bytes la clave
            String keyString = textKey.Text;

            byte[] key = hexStrToPackedByteArray(keyString);

            //Paso a Bytes el IV
            String ivString = textIV.Text;

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

                    case "EMV":
                        des.Padding = PaddingMode.None;
                        break;

                }


                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();


                    String cadena = null;
                    byte[] resultado = null;

                    if (tipoPadding.Equals("EMV"))
                    {

                        resultado = removeEMVPadding(memoryStream.ToArray());

                        if (checkHexadecimal.ThreeState == false) {
                            cadena = ConvertHex(packedByteArrayToHexStr(resultado, 0, resultado.Length));
                        }else {
                            cadena = packedByteArrayToHexStr(resultado, 0, resultado.Length);
                        }
                        
                    }

                    else {

                        if (checkHexadecimal.ThreeState == false)
                        {
                            cadena = ConvertHex(packedByteArrayToHexStr(memoryStream.ToArray(), 0, memoryStream.ToArray().Length));
                        }
                        else
                        {
                            cadena = packedByteArrayToHexStr(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
                        }
                    }

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

                    case "EMV":
                        des.Padding = PaddingMode.None;
                        break;

                }


                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(),
                        CryptoStreamMode.Write);


                    String cadena = null;
                    byte[] resultado = null;

                    if (tipoPadding.Equals("EMV"))
                    {

                        resultado = removeEMVPadding(memoryStream.ToArray());

                        if (checkHexadecimal.ThreeState == false)
                        {
                            cadena = ConvertHex(packedByteArrayToHexStr(resultado, 0, resultado.Length));
                        }
                        else
                        {
                            cadena = packedByteArrayToHexStr(resultado, 0, resultado.Length);
                        }

                    }

                    else
                    {

                        if (checkHexadecimal.ThreeState == false)
                        {
                            cadena = ConvertHex(packedByteArrayToHexStr(memoryStream.ToArray(), 0, memoryStream.ToArray().Length));
                        }
                        else
                        {
                            cadena = packedByteArrayToHexStr(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
                        }
                    }

                    //Mostrar cadena
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

                    case "EMV":
                        des.Padding = PaddingMode.None;
                        break;

                }


                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    String cadena = null;
                    byte[] resultado = null;


                    if (tipoPadding.Equals("EMV"))
                    {

                        resultado = addEMVPadding(memoryStream.ToArray(),8);
                        cadena = packedByteArrayToHexStr(resultado, 0, resultado.Length);

                    }

                    else {

                        cadena = packedByteArrayToHexStr(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
                    }

                    myLog = myLog + "Texto Cifrado: " + cadena + "\r\n";

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

                    case "EMV":
                        des.Padding = PaddingMode.None;
                        break;

                }


                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();


                    String cadena = null;
                    byte[] resultado = null;


                    if (tipoPadding.Equals("EMV"))
                    {

                        resultado = addEMVPadding(memoryStream.ToArray(), 8);
                        cadena = packedByteArrayToHexStr(resultado, 0, resultado.Length);

                    }

                    else {

                        cadena = packedByteArrayToHexStr(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
                    }

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
                try
                {
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

            try
            {

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

            }
            catch (Exception ex)
            {
                MessageBox.Show("packedByteArrayToHexStr() - " + ex.Message);
            }

            return stringBuffer.ToString();
        }


        public static byte[] numStrToPackedByteArray(string str)
        {
            try
            {

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
                        message = "numStrToPackedByteArray() - carácter inválido en el string - " + str;
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
            catch (Exception ex)
            {
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


        /**
	 * Adding EMV Padding. This padding is: 0x80 (startPadding) and adding 0x00 (bodyPadding) to block size.
	 * If block size is achived with the <i>startPadding</i>, then is necessary to add the <i>bodyPadding</i>
	 * to complete the new block size.
	 * @param data Data to add padding.
	 * @param blockLength The block size (in bytes).
	 * @return the data with padding.
	 * @throws Exception
	 */
        public static byte[] addEMVPadding(byte[] data, int blockLength)
        {
            byte[] buffer = null; //Resultado
            String mensajeError = null;

            try
            {
                //Comprobaciones iniciales
                if (blockLength <= 0)
                {
                    mensajeError = "Exist a problem with the 'blockLength' input parameter";
                    throw new System.Exception();
                }
                if (data == null || data.Length == 0)
                {
                    mensajeError = "Exist a problem with the 'data' input parameter";
                    throw new System.Exception();
                }

                /* Calculo de padding  y tamaño de buffer salida */
                int bufferlength = ((data.Length / blockLength) + 1) * blockLength; //Tam. buffer salida

                /* Crear Buffer */
                buffer = new byte[bufferlength];

                /* Copiar datos al buffer y añadir padding */
                //Copar datos
                Array.Copy(data, 0, buffer, 0, data.Length);

                //Añadir Padding
                buffer[data.Length] = (byte)0x80;
                for (int i = data.Length + 1; i < bufferlength; i++)
                {
                    buffer[i] = (byte)0x00;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(mensajeError);

            }


            return buffer;
        }

        /**
         * Remove the EMV padding. This padding is: 0x80 (startPadding) and adding 0x00 (bodyPadding) to block size.
         * If block size is achived with the <i>startPadding</i>, then is necessary to add the <i>bodyPadding</i>
         * to complete the new block size.
         * @param data Data to remove padding.
         * @return data without padding.
         * @throws Exception
         */
        public static byte[] removeEMVPadding(byte[] data)
        {
            String mensajeError = null;

            byte[] buffer = null; //Resultado

            try
            {

                /* Validar parametros de entrada */
                if (data == null || data.Length < 2)
                {
                    mensajeError = "Exist a problem with the 'data' input parameter";
                    throw new System.Exception();
                }

                /* Encontrar longitud de datos */
                int bufferLength = data.Length;

                for (bufferLength--; bufferLength > 0; bufferLength--)
                {
                    if (data[bufferLength] == (byte)0x00) break;
                    if (data[bufferLength] != (byte)0x80)
                    {
                        mensajeError = "EMV padding incorrect ";
                        throw new System.Exception();
                    }
                }
                if (bufferLength <= 0)
                {

                    mensajeError = "EMV padding incorrect - block contains only zeroes ";
                    throw new System.Exception();
                }

                /* Eliminar padding */
                buffer = new byte[bufferLength];
                Array.Copy(data, 0, buffer, 0, bufferLength);

            }
            catch (Exception ex)

            {
                MessageBox.Show(mensajeError);
            }

            return buffer;
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

        private static byte[] MacRetail(byte[] key, byte[] dataToEncrypt, string tipoPadding)
        {
            byte[] result = null;

            byte[] key1 = new byte[8];
            Array.Copy(key, 0, key1, 0, 8);
            byte[] key2 = new byte[8];
            Array.Copy(key, 8, key2, 0, 8);

            DES des1 = DES.Create();
            des1.Key = key1;
            des1.Mode = CipherMode.CBC;

            // aqui definimos el tipo de padding
            switch (tipoPadding)
            {

                case "PKCS7":
                    des1.Padding = PaddingMode.PKCS7;
                    break;

                case "Zeros":
                    des1.Padding = PaddingMode.Zeros;
                    break;

                case "None":
                    des1.Padding = PaddingMode.None;
                    break;

                case "ANSIX923":
                    des1.Padding = PaddingMode.ANSIX923;
                    break;

                case "ISO10126":
                    des1.Padding = PaddingMode.ISO10126;
                    break;

                case "EMV":
                    des1.Padding = PaddingMode.None;
                    break;

            }

            //  des1.Padding = PaddingMode.None;

            //Vector inicializacion a ceros
            des1.IV = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            DES des2 = DES.Create();
            des2.Key = key2;
            des2.Mode = CipherMode.CBC;

            switch (tipoPadding)
            {

                case "PKCS7":
                    des2.Padding = PaddingMode.PKCS7;
                    break;

                case "Zeros":
                    des2.Padding = PaddingMode.Zeros;
                    break;

                case "None":
                    des2.Padding = PaddingMode.None;
                    break;

                case "ANSIX923":
                    des2.Padding = PaddingMode.ANSIX923;
                    break;

                case "ISO10126":
                    des2.Padding = PaddingMode.ISO10126;
                    break;
                case "EMV":
                    des2.Padding = PaddingMode.None;

                    break;

            }

            // des2.Padding = PaddingMode.None;

            //Vector inicializacion a ceros
            des2.IV = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            if (tipoPadding.Equals("EMV"))
            {
                // Llamo a rellenar padding previamente.
                dataToEncrypt = addEMVPadding(dataToEncrypt, 8);
            }


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
            bool resultado = int.TryParse(comboLongKey.SelectedItem.ToString(), out value);

            byte[] key = new byte[value]; // For a 192-bit key = 24 bytes
            rng.GetBytes(key);

            textGenerateKey.Text = ByteArrayToHexString(key);

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

            //Extraccion de modo de padding
            String tipoPadding = comboBoxPaddingMAC.SelectedItem.ToString();


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
                    mac = MacRetail(key, dataToEncrypt, tipoPadding);
                    break;
            }

            string cadena = packedByteArrayToHexStr(mac, 0, mac.Length);

            textBoxMAC.Text = cadena;


        }

        private void comboBoxMAC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPaddingMAC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkStepByStep.ThreeState)
            {
                checkStepByStep.ThreeState = true;
             
            }
            else
            {
                checkStepByStep.ThreeState = false;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Claves Claves = new Claves();
            Claves.Show();
        }

        private void checkHexadecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkHexadecimal.ThreeState)
            {
                checkHexadecimal.ThreeState = true;

            }
            else
            {
                checkHexadecimal.ThreeState = false;
            }
        }
    }
}
