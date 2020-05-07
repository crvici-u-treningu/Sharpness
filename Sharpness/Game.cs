using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpness
{
    public abstract class Game
    {
        public abstract void Config(ref Config config);
        public abstract void Update(Input input);
        public abstract void Draw(Canvas canvas);

        public void Quit()
        {
            Environment.Exit(0);
        }
    }

    public static class GameFinder
    {
        public static Game GetImplementation()
        {
            List<Assembly> allAssemblies = new List<Assembly>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
                allAssemblies.Add(Assembly.LoadFile(dll));

            var list = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(Game).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .ToList();

            if (list.Count == 1)
            {
                return (Game)Activator.CreateInstance(list[0]);
            } 
            else if(list.Count > 1)
            { 
                var dialog = new GameFinderDialog(list);
                dialog.ShowDialog();
                if (dialog.DialogResult == DialogResult.OK)
                {
                    return (Game)Activator.CreateInstance(dialog.Result);
                }
                else
                    Environment.Exit(-1);
            }

            Environment.Exit(0);
            return null;
        }
    }
}
