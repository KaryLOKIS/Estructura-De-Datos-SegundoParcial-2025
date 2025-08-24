
class Program
{
    static void Main()
    {
        // 1. Generar 500 ciudadanos ficticios
        System.Collections.Generic.HashSet<string> todos = new System.Collections.Generic.HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            todos.Add("Ciudadano " + i);
        }

        // 2. Crear vacunados con Pfizer y AstraZeneca (75 cada uno)
        System.Random rnd = new System.Random();
        System.Collections.Generic.List<string> listaTodos = new System.Collections.Generic.List<string>(todos);

        System.Collections.Generic.HashSet<string> pfizer = new System.Collections.Generic.HashSet<string>();
        System.Collections.Generic.HashSet<string> astrazeneca = new System.Collections.Generic.HashSet<string>();

        while (pfizer.Count < 75)
            pfizer.Add(listaTodos[rnd.Next(listaTodos.Count)]);

        while (astrazeneca.Count < 75)
            astrazeneca.Add(listaTodos[rnd.Next(listaTodos.Count)]);

        // 3. Operaciones de conjuntos
        System.Collections.Generic.HashSet<string> noVacunados = new System.Collections.Generic.HashSet<string>(todos);
        noVacunados.ExceptWith(pfizer);
        noVacunados.ExceptWith(astrazeneca);

        System.Collections.Generic.HashSet<string> dobleDosis = new System.Collections.Generic.HashSet<string>(pfizer);
        dobleDosis.IntersectWith(astrazeneca);

        System.Collections.Generic.HashSet<string> soloPfizer = new System.Collections.Generic.HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astrazeneca);

        System.Collections.Generic.HashSet<string> soloAstrazeneca = new System.Collections.Generic.HashSet<string>(astrazeneca);
        soloAstrazeneca.ExceptWith(pfizer);

        // 4. Mostrar resultados en consola
        System.Console.WriteLine("Ciudadanos que NO se han vacunado: " + noVacunados.Count);
        System.Console.WriteLine("Ciudadanos con ambas dosis: " + dobleDosis.Count);
        System.Console.WriteLine("Ciudadanos SOLO con Pfizer: " + soloPfizer.Count);
        System.Console.WriteLine("Ciudadanos SOLO con AstraZeneca: " + soloAstrazeneca.Count);
    }
}
