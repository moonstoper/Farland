using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// public static class SaveManager
//     {public static void SavePlayer (PlayerMovemnt player)
//     {
//         BinaryFormatter formatter = new BinaryFormatter();
//         string path = Application.persistentDataPath + "/savegame.save";
//         FileStream stream = new FileStream(path, FileMode.Create);
//         PlayerPref data =new PlayerPref(player);
//     }
// }