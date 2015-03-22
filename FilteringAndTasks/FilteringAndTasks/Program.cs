using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace FilteringAndTasks
{
    class Objeto
    {
        public int Id { get; set; }

        public bool Sleep()
        {
            for (int i = 0; i < 100000; i++) { }
            return true;
        }
    }



    class Program
    {
        private const int MAXIMO_OBJETOS_POR_TASK = 200;

        static void Main(string[] args)
        {
            Func<Objeto, bool> funcionFiltro = o => o.Sleep() && (o.Id > 100);
            List<Objeto> objetos = new List<Objeto>();
            List<Objeto> objetosFiltrados;

            for (int i = 0; i < 100000; i++)
            {
                objetos.Add(new Objeto { Id = i + 1 });
            }

            Stopwatch sw = new Stopwatch();

            sw.Start();
            objetosFiltrados = FilterWith(objetos, funcionFiltro);
            sw.Stop();
            Console.WriteLine("FilterWith: {0} objetos en {1} ms", objetosFiltrados.Count(), sw.ElapsedMilliseconds);

            sw.Reset();

            sw.Start();
            objetosFiltrados = FilterWithTasks(objetos, funcionFiltro);
            sw.Stop();
            Console.WriteLine("FilterWithTasks: {0} objetos en {1} ms", objetosFiltrados.Count(), sw.ElapsedMilliseconds);

            Console.ReadLine();
        }



        private static List<Objeto> FilterWithTasks(List<Objeto> lista, Func<Objeto, bool> filtro)
        {
            int availableTasks = lista.Count / MAXIMO_OBJETOS_POR_TASK;

            int numeroObjetosPorTask = MAXIMO_OBJETOS_POR_TASK;

            // Si la lista no está vacía, en realidad habrá una task aunque la división nos haya dado 0.
            // La peculiaridad es que no habrá tasks que abarquen el total de NUMERO_OBJETOS_POR_TASK.
            // Si sólo hay una task, se convierte en "la última" y en el bucle se le asigna el total de los objetos de la lista.
            if (availableTasks == 0 && lista.Any()) { availableTasks = 1; }

            int indiceInicio = 0;
            Task<List<Objeto>>[] tasks = new Task<List<Objeto>>[availableTasks];

            for (int i = 0; i < availableTasks; i++)
            {
                indiceInicio = i * numeroObjetosPorTask;
                if (i + 1 == availableTasks)
                {
                    numeroObjetosPorTask = lista.Count - indiceInicio;
                }
                List<Objeto> tmp = lista.GetRange(indiceInicio, numeroObjetosPorTask);
                tasks[i] = Task<List<Objeto>>.Factory.StartNew(() => FilterWith(tmp, filtro));
            }
            Task.WaitAll(tasks);

            List<Objeto> objetosFiltrados = new List<Objeto>();

            foreach (Task<List<Objeto>> task in tasks)
            {
                objetosFiltrados.AddRange(task.Result);
            }
            return objetosFiltrados;
        }



        private static List<Objeto> FilterWith(List<Objeto> lista, Func<Objeto, bool> filtro)
        {
            List<Objeto> objetosFiltrados = new List<Objeto>();

            foreach (Objeto obj in lista)
            {
                if (filtro(obj)) { objetosFiltrados.Add(obj); }
            }

            return objetosFiltrados;
        }
    }
}
