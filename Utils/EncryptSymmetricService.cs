using Google.Cloud.Kms.V1;
using Google.Protobuf;
using System.Text;

namespace Auth0_Blazor.Utils
{
    public class EncryptSymmetricService
    {
        public string EncryptSymmetric(
            string message = "Este es un mensaje cifrado",
          string projectId = "blazorserverdb", string locationId = "global", string keyRingId = "TestKeyRing", string keyId = "TestKey")
        {
            string credentialFileName = "blazorserverdb-firebase-adminsdk-d6ztc-72ee8cbfb5.json";
            string CredentialPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", credentialFileName);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", CredentialPath);

            // Create the client.
            KeyManagementServiceClient client = KeyManagementServiceClient.Create();

            // Build the key name.
            CryptoKeyName keyName = new CryptoKeyName(projectId, locationId, keyRingId, keyId);

            // Convert the message into bytes. Cryptographic plaintexts and ciphertexts are always byte arrays.
            byte[] plaintext = Encoding.UTF8.GetBytes(message);

            // Call the API.
            EncryptResponse result = client.Encrypt(keyName, ByteString.CopyFrom(plaintext));

            // Convert the ciphertext to a Base64 string.
            string encryptedMessage = Convert.ToBase64String(result.Ciphertext.ToByteArray());

            return encryptedMessage;
        }
    }
}
