using System;

namespace Practice.Interfaces
{
    /// <summary>
    /// Defines a contract for file encryption operations.
    /// This interface provides methods for encrypting and decrypting files using AES encryption.
    /// </summary>
    /// <remarks>
    /// The IFileEncryption interface is designed to:
    /// - Provide secure file encryption
    /// - Support file decryption
    /// - Handle encryption resources
    /// - Ensure secure operations
    /// 
    /// Key design considerations:
    /// - Encryption security
    /// - Key management
    /// - Resource cleanup
    /// - Error handling
    /// 
    /// Implementation requirements:
    /// - Use secure encryption algorithms
    /// - Handle keys and IVs properly
    /// - Implement proper error handling
    /// - Clean up sensitive data
    /// </remarks>
    public interface IFileEncryption : IDisposable
    {
        /// <summary>
        /// Encrypts a file using AES encryption with a password-derived key.
        /// </summary>
        /// <param name="sourceFile">The path of the file to encrypt.</param>
        /// <param name="destinationFile">The path where the encrypted file will be saved.</param>
        /// <param name="password">The password to use for encryption.</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the source file does not exist.</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs.</exception>
        /// <exception cref="CryptographicException">Thrown when an encryption error occurs.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the encryption manager has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Validate all parameters
        /// - Generate secure key from password
        /// - Use unique IV for each encryption
        /// - Handle encryption securely
        /// - Clean up sensitive data
        /// </remarks>
        void EncryptFile(string sourceFile, string destinationFile, string password);

        /// <summary>
        /// Decrypts a file that was encrypted using the EncryptFile method.
        /// </summary>
        /// <param name="sourceFile">The path of the encrypted file.</param>
        /// <param name="destinationFile">The path where the decrypted file will be saved.</param>
        /// <param name="password">The password used for encryption.</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the source file does not exist.</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs.</exception>
        /// <exception cref="CryptographicException">Thrown when a decryption error occurs.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the encryption manager has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Validate all parameters
        /// - Generate key from password
        /// - Read IV from encrypted file
        /// - Handle decryption securely
        /// - Clean up sensitive data
        /// </remarks>
        void DecryptFile(string sourceFile, string destinationFile, string password);
    }
}