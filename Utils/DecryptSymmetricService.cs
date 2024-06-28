using Google.Cloud.Kms.V1;
using Google.Protobuf;
using System.Text;

namespace Auth0_Blazor.Utils
{
    public class DecryptSymmetricService
    {
        public string DecryptSymmetric(
          string base64Ciphertext, string projectId = "blazorserverdb", string locationId = "global", string keyRingId = "TestKeyRing", string keyId = "TestKey")
        {
            string credentialFileName = "blazorserverdb-firebase-adminsdk-d6ztc-72ee8cbfb5.json";
            string CredentialPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", credentialFileName);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", CredentialPath);

            // Create the client.
            KeyManagementServiceClient client = KeyManagementServiceClient.Create();

            // Build the key name.
            CryptoKeyName keyName = new CryptoKeyName(projectId, locationId, keyRingId, keyId);

            // Convert the Base64 string to byte array
            byte[] ciphertext = Convert.FromBase64String(base64Ciphertext);

            // Call the API.
            DecryptResponse result = client.Decrypt(keyName, ByteString.CopyFrom(ciphertext));

            // Get the plaintext. Cryptographic plaintexts and ciphertexts are always byte arrays.
            byte[] plaintext = result.Plaintext.ToByteArray();

            // Return the result.
            return Encoding.UTF8.GetString(plaintext);
        }
    }
}
