using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProveraRadnikaJun19
{
    class Repository
    {
        private static object locker = true;
        private static Repository instance;

        public List<Radnik> radnici;
      //  public List<String> promene;

        protected Repository()
        {
         //   promene = new List<string>();
            radnici = new List<Radnik>();
        }

        public static Repository Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new Repository();
                }

                return instance;
            }
        }

    }
}
