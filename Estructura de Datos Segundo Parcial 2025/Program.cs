
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // 1. Generar 500 ciudadanos ficticios
        HashSet<string> todos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            todos.Add("Ciudadano " + i);
        }

        // 2. Crear vacunados con Pfizer y AstraZeneca (75 cada uno)
        Random rnd = new Random();
        List<string> listaTodos = todos.ToList();

        HashSet<string> pfizer = new HashSet<string>();
        HashSet<string> astrazeneca = new HashSet<string>();

        while (pfizer.Count < 75)
            pfizer.Add(listaTodos[rnd.Next(listaTodos.Count)]);

        while (astrazeneca.Count < 75)
            astrazeneca.Add(listaTodos[rnd.Next(listaTodos.Count)]);

        // 3. Operaciones de conjuntos
        HashSet<string> noVacunados = new HashSet<string>(todos);
        noVacunados.ExceptWith(pfizer);
        noVacunados.ExceptWith(astrazeneca);

        HashSet<string> dobleDosis = new HashSet<string>(pfizer);
        dobleDosis.IntersectWith(astrazeneca);

        HashSet<string> soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astrazeneca);

        HashSet<string> soloAstrazeneca = new HashSet<string>(astrazeneca);
        soloAstrazeneca.ExceptWith(pfizer);

        // 4. Mostrar resultados
        Console.WriteLine("Ciudadanos que NO se han vacunado: " + noVacunados.Count);
        Console.WriteLine("Ciudadanos con ambas dosis: " + dobleDosis.Count);
        Console.WriteLine("Ciudadanos SOLO con Pfizer: " + soloPfizer.Count);
        Console.WriteLine("Ciudadanos SOLO con AstraZeneca: " + soloAstrazeneca.Count);
    }
}
