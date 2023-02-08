using System.Text.Json;

namespace information_system.General
{
    public static class SerializationDeserialization
    {
        public static void Serialize<T>(List<T> objectToSerialize, string filePath)
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize<List<T>>(objectToSerialize, options);
            File.WriteAllText(filePath, json);
        }

        public static List<T> Deserialize<T>(string filePath)
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();

            string json = File.ReadAllText(filePath);
            try
            {
                List<T> deserializedObject = JsonSerializer.Deserialize<List<T>>(json);
                return deserializedObject;
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }
    }
}
