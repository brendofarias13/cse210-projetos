Fracao fracao1 = new Fracao();

Console.WriteLine(fracao1.ObterFracaoEmTexto());
Console.WriteLine(fracao1.GetNumerador());
Console.WriteLine(fracao1.GetDenominador());

Fracao fracao2 = new Fracao(5);

Console.WriteLine(fracao2.ObterFracaoEmTexto());
Console.WriteLine(fracao2.GetNumerador());

Fracao fracao3 = new Fracao(3, 4);

Console.WriteLine(fracao3.ObterFracaoEmTexto());
Console.WriteLine(fracao3.ObterFracaoEmDecimal());

Fracao fracao4 = new Fracao(1, 3);

Console.WriteLine(fracao4.ObterFracaoEmTexto());
Console.WriteLine(fracao4.ObterFracaoEmDecimal());

fracao3.SetNumerador(1);
fracao3.SetDenominador(2);

Console.WriteLine(fracao3.ObterFracaoEmTexto());
Console.WriteLine(fracao3.ObterFracaoEmDecimal());