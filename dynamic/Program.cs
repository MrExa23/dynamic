List<(int litr, int cena)> sperk = new()
/*
{
	(3,60),(4,100),(2,120)
}*/
;
int pocetSperku = 10;
int litry = 10;
int[,] tab = new int[pocetSperku + 1, litry+1];


Random rnd = new Random();
for (int i = 0; i < pocetSperku; i++)
{
	int sperkLitry = rnd.Next(1,5);
	int sperkcena = rnd.Next(10, 100);
	sperk.Add((sperkLitry, sperkcena));
}


for (int i = 0; i < litry+1; i++)
{
	tab[0, i] = 0;
}

for (int i = 1; i < pocetSperku+1; i++)
{
	int k = i - 1;
	for (int j = 0; j < litry+1; j++)
	{
		if (j < sperk[k].litr || sperk[k].cena + tab[i - 1, j - sperk[k].litr] < tab[i-1,j]) //pokud se sperk nevejde nebo pokud sperk neni lepsi, pouzijeme vyssi policko
		{
            tab[i, j] = tab[i - 1, j];
        }
		else
		{
			tab[i, j] = sperk[k].cena+tab[i-1, j-sperk[k].litr];
		}
    }
}
for(int i = 0; i < pocetSperku + 1; i++)
{
    
    for (int j = 0; j < litry+1; j++)
    {
		Console.Write(tab[i,j]+" ");
    }
    Console.WriteLine();
}
Console.WriteLine("pocet litru:"+litry+" pocet sperku "+pocetSperku);

for (int i = 0; i < pocetSperku; i++)
{
	Console.WriteLine(sperk[i].litr+" litru " + sperk[i].cena+" cena");
}

Console.WriteLine();


List<(int litr, int cena)> pouzitySperk = new();

int iT = pocetSperku;
int jT = litry;
while (iT>0&&jT>0)
{
	if (tab[iT,jT]!= (tab[iT-1, jT]))
	{
		pouzitySperk.Add(sperk[iT-1]);
		jT = jT - sperk[iT - 1].litr;
	}
    iT--;
}
for (int i = 0; i < pouzitySperk.Count; i++)
{
	Console.WriteLine(pouzitySperk[i]);
}







