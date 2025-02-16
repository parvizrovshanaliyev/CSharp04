using System.Security.Cryptography;
using System.Text;

namespace OOP.SealedClass;

/// <summary>
/// A sealed class that manages secure configuration settings.
/// This class cannot be inherited to ensure security measures cannot be overridden.
/// </summary>
/// <remarks>
/// Sealed classes are used when:
/// 1. The class's implementation must not be modified
/// 2. Security is a primary concern
/// 3. The class's behavior must remain consistent
/// </remarks>
public sealed class SecureConfiguration
{
    private readonly Dictionary<string, string> _secureSettings;
    private readonly string _encryptionKey;
    private static SecureConfiguration? _instance;
    private static readonly object _lock = new();

    /// <summary>
    /// Private constructor to enforce singleton pattern and prevent direct instantiation.
    /// </summary>
    private SecureConfiguration()
    {
        _secureSettings = new Dictionary<string, string>();
        _encryptionKey = GenerateEncryptionKey();
    }

    /// <summary>
    /// Gets the singleton instance of SecureConfiguration.
    /// </summary>
    public static SecureConfiguration Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new SecureConfiguration();
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// Adds or updates a secure setting with encryption.
    /// </summary>
    /// <param name="key">The setting key</param>
    /// <param name="value">The setting value to encrypt</param>
    public void SetSecureSetting(string key, string value)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        string encryptedValue = EncryptValue(value);
        _secureSettings[key] = encryptedValue;
    }

    /// <summary>
    /// Retrieves and decrypts a secure setting.
    /// </summary>
    /// <param name="key">The setting key</param>
    /// <returns>The decrypted setting value</returns>
    public string GetSecureSetting(string key)
    {
        if (!_secureSettings.TryGetValue(key, out string? encryptedValue))
            throw new KeyNotFoundException($"Setting '{key}' not found.");

        return DecryptValue(encryptedValue);
    }

    /// <summary>
    /// Removes a secure setting.
    /// </summary>
    /// <param name="key">The setting key to remove</param>
    public void RemoveSecureSetting(string key)
    {
        if (!_secureSettings.Remove(key))
            throw new KeyNotFoundException($"Setting '{key}' not found.");
    }

    /// <summary>
    /// Lists all setting keys (values remain encrypted).
    /// </summary>
    /// <returns>Array of setting keys</returns>
    public string[] ListSettings()
    {
        return _secureSettings.Keys.ToArray();
    }

    /// <summary>
    /// Generates a random encryption key.
    /// </summary>
    private string GenerateEncryptionKey()
    {
        byte[] key = new byte[32]; // 256 bits
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(key);
        }
        return Convert.ToBase64String(key);
    }

    /// <summary>
    /// Encrypts a value using AES encryption.
    /// </summary>
    private string EncryptValue(string value)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;

        byte[] keyBytes = Convert.FromBase64String(_encryptionKey);
        byte[] valueBytes = Encoding.UTF8.GetBytes(value);

        using var aes = Aes.Create();
        aes.Key = keyBytes;
        aes.GenerateIV();

        using var encryptor = aes.CreateEncryptor();
        byte[] encryptedBytes = encryptor.TransformFinalBlock(valueBytes, 0, valueBytes.Length);

        // Combine IV and encrypted data
        byte[] result = new byte[aes.IV.Length + encryptedBytes.Length];
        Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
        Buffer.BlockCopy(encryptedBytes, 0, result, aes.IV.Length, encryptedBytes.Length);

        return Convert.ToBase64String(result);
    }

    /// <summary>
    /// Decrypts a value using AES encryption.
    /// </summary>
    private string DecryptValue(string encryptedValue)
    {
        if (string.IsNullOrEmpty(encryptedValue)) return string.Empty;

        byte[] fullBytes = Convert.FromBase64String(encryptedValue);
        byte[] keyBytes = Convert.FromBase64String(_encryptionKey);

        using var aes = Aes.Create();
        byte[] iv = new byte[aes.IV.Length];
        byte[] encryptedBytes = new byte[fullBytes.Length - iv.Length];

        // Separate IV and encrypted data
        Buffer.BlockCopy(fullBytes, 0, iv, 0, iv.Length);
        Buffer.BlockCopy(fullBytes, iv.Length, encryptedBytes, 0, encryptedBytes.Length);

        aes.Key = keyBytes;
        aes.IV = iv;

        using var decryptor = aes.CreateDecryptor();
        byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
        return Encoding.UTF8.GetString(decryptedBytes);
    }
}