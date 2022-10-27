using System.Diagnostics;
using dotnet_dictionary;

var notas = new NotaCorretagem()
.GerarNotasCorretagem(100000);

var notasDictionary = notas.ToDictionary(n => $"{n.Cci}-{n.NumeroDaConta}-{n.NumeroNota}");


foreach (var n in notas)
{
    var partitionKey = $"{n.Cci}-{n.NumeroDaConta}-{n.NumeroNota}";

    if(notasDictionary.TryGetValue( partitionKey, out var notaCorretagem ))
    {
      Console.WriteLine($"{notaCorretagem.Cci}-{notaCorretagem.Nome}");
    }
}  


foreach (var n in notas)
{
    var notaCorretagem =  notas.Where(x => x.Cci == n.Cci && x.NumeroDaConta == n.NumeroDaConta && x.NumeroNota == n.NumeroNota).FirstOrDefault();
    Console.WriteLine($"{notaCorretagem.Cci}-{notaCorretagem.Nome}");
 
}



    // var transactions = new List<Transactions>();
    // for (int i = 0; i < 10000000; i++)
    // {
    //     transactions.Add(new Transactions(i, $"Mark", $"{10}"));
    // }

    // Stopwatch _timer2 = new Stopwatch();

    // //01
    // var dic = new Dictionary<string, Transactions>();
    // foreach (var item in transactions)
    // {
    //     dic.Add(item.Name, item);
    // }
    // //02 
    // var listaDic = transactions.ToDictionary(x => x.Id);

    // _timer2.Start();
    //     foreach (var item in transactions)
    //     {
    //         var r = listaDic[item.Id];
    //     }  
    // _timer2.Stop();
    // Console.WriteLine($"Caso 02 demorou: {_timer2.ElapsedMilliseconds}");
    // _timer2.Reset();

    // _timer2.Start();
    //     foreach (var item in transactions)
    //     {
    //         var r = transactions.Where(x => x.Id == item.Id);
    //     }    
    // _timer2.Stop();
    // Console.WriteLine($"Caso 02 demorou: {_timer2.ElapsedMilliseconds}");
    // _timer2.Reset();
            
        
    // listaDic = null;