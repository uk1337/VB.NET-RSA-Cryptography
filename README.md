# RSA Cryptography
This project demonstrates how to use RSA cryptography to generate a key pair, encrypt and decrypt messages using the generated keys. The code is written in VB.NET.


## Code Overview
The code consists of a single module named RSACryptography which contains the following functions:


### GenerateKeyPair
```vb.net
Public Function GenerateKeyPair(ByVal keySize As Integer) As RSAKeyPair
```
This function generates an RSA key pair with the specified key size. The key pair is returned as an RSAKeyPair structure, which contains the private and public keys.


### Encrypt
```vb.net
Public Function GenerateKeyPair(ByVal keySize As Integer) As RSAKeyPair
```
This function encrypts the specified data using the specified public key and padding mode. The encrypted data is returned as a byte array.


### Decrypt
```vb.net
Public Function Decrypt(ByVal data As Byte(), ByVal privateKey As String, ByVal paddingMode As RSAEncryptionPaddingMode) As Byte()
```
This function decrypts the specified data using the specified private key and padding mode. The decrypted data is returned as a byte array.


### GetMaxDataLength
```vb.net
Public Function GetMaxDataLength(ByVal keySize As Integer, ByVal paddingMode As RSAEncryptionPaddingMode) As Integer
```
This function returns the maximum data length that can be encrypted using the specified key size and padding mode.


## Example
The Main method in the Module1 module provides an example of how to use the RSACryptography module to generate a key pair, encrypt and decrypt a message using the generated keys. Here's the example code:
```vb.net
Sub Main()

    Dim keySize As Integer = 4096
    Dim paddingMode As RSAEncryptionPaddingMode = RSAEncryptionPaddingMode.Oaep

    'Generate RSA key pair
    Dim keyPair As RSAKeyPair = GenerateKeyPair(keySize)

    'Encrypt and decrypt a sample message
    Dim message As String = "Hello World"
    Dim encryptedMessage As Byte() = Encrypt(Encoding.UTF8.GetBytes(message), keyPair.PublicKey, paddingMode)
    Dim decryptedMessage As String = Encoding.UTF8.GetString(Decrypt(encryptedMessage, keyPair.PrivateKey, paddingMode))

    'Display the encrypted and decrypted messages
    Console.WriteLine(vbNewLine)
    Console.WriteLine("Encrypted Message: {0}", Convert.ToBase64String(encryptedMessage))
    Console.WriteLine(vbNewLine)
    Console.WriteLine("Decrypted Message: {0}", decryptedMessage)
End Sub
```
The code generates an RSA key pair with a key size of 4096 bits, encrypts a message "Hello World" using the public key, and then decrypts the encrypted message using the private key. The decrypted message is then displayed on the console.


## License
This module is licensed under the MIT License.
