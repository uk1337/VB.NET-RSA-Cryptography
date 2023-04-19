Public Module RSACryptography

    'RSA key pair structure
    Public Structure RSAKeyPair
        Public PrivateKey As String
        Public PublicKey As String
    End Structure

    'Generate an RSA key pair with the specified key size
    Public Function GenerateKeyPair(ByVal keySize As Integer) As RSAKeyPair
        Dim rsa As New RSACryptoServiceProvider(keySize)
        rsa.PersistKeyInCsp = False
        Dim privateKey As String = rsa.ToXmlString(True)
        Dim publicKey As String = rsa.ToXmlString(False)
        Dim keyPair As RSAKeyPair
        keyPair.PrivateKey = privateKey
        keyPair.PublicKey = publicKey
        Return keyPair
    End Function

    'Encrypt data using the specified public key and padding mode
    Public Function Encrypt(ByVal data As Byte(), ByVal publicKey As String, ByVal paddingMode As RSAEncryptionPaddingMode) As Byte()
        Dim rsa As New RSACryptoServiceProvider()
        rsa.FromXmlString(publicKey)
        Dim encryptedData As Byte() = rsa.Encrypt(data, paddingMode)
        Return encryptedData
    End Function

    'Decrypt data using the specified private key and padding mode
    Public Function Decrypt(ByVal data As Byte(), ByVal privateKey As String, ByVal paddingMode As RSAEncryptionPaddingMode) As Byte()
        Dim rsa As New RSACryptoServiceProvider()
        rsa.FromXmlString(privateKey)
        Dim decryptedData As Byte() = rsa.Decrypt(data, paddingMode)
        Return decryptedData
    End Function

    'Get the maximum data length that can be encrypted using the specified key size and padding mode
    Public Function GetMaxDataLength(ByVal keySize As Integer, ByVal paddingMode As RSAEncryptionPaddingMode) As Integer
        Dim rsa As New RSACryptoServiceProvider(keySize)
        Dim blockSize As Integer

        If paddingMode = RSAEncryptionPaddingMode.Pkcs1 Then
            ' PKCS1 padding mode
            blockSize = (keySize / 8) - 11
        Else
            ' OAEP padding mode
            blockSize = (keySize / 8) - 2 * 160 / 8 - 2
        End If

        Return blockSize
    End Function

End Module
