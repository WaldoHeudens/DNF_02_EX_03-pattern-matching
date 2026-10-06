// Dit voorbeeld toont pattern matching via een switch expression,
// met relationele patronen, type patronen en property patronen.
// Onderaan komt nullable ook aan bod.

// Een switch expression geeft een WAARDE terug. Let op de => en de _.
int temperatuur = 3;

string fase = temperatuur switch
{
    < 0 => "ijs",
    0 => "vriespunt",
    > 0 and < 100 => "water",
    _ => "stoom", // _ is het standaardgeval (elk ander getal)
};

Console.WriteLine($"Bij {temperatuur} graden: {fase}");

// Type patronen: reageer op het werkelijke type van een object.
object[] waarden = [42, "hallo", 3.14, true];
foreach (object waarde in waarden)
{
    string omschrijving = waarde switch
    {
        int i => $"geheel getal {i}",
        string s => $"tekst van {s.Length} tekens",
        double d => $"kommagetal {d}",
        _ => "iets anders",
    };
    Console.WriteLine(omschrijving);
}

// Property patronen: match op properties van een object.
Bestelling[] bestellingen =
[
    new Bestelling("Boek", 3),
    new Bestelling("Pen", 0),
    new Bestelling("Laptop", 1),
];

foreach (Bestelling bestelling in bestellingen)
{
    string status = bestelling switch
    {
        { Aantal: 0 } => "uitverkocht",
        { Aantal: 1 } => "laatste exemplaar",
        { Aantal: > 1 } => "op voorraad",
        _ => "onbekend",
    };
    Console.WriteLine($"{bestelling.Product}: {status}");
}

// Nullable reference types: een string? mag null zijn.
string? ingevoerdeNaam = null;

// ?. (null-conditional): roept .Length enkel aan als de waarde niet null is,
// anders is het resultaat null.
int? lengte = ingevoerdeNaam?.Length;
Console.WriteLine($"Lengte van de naam: {lengte}"); // niets: null

// ?? (null-coalescing): gebruik de rechterkant als de linkerkant null is.
string weergave = ingevoerdeNaam ?? "onbekende";
Console.WriteLine($"Hallo, {weergave}!");

// Een positional record: compacte manier om een klein datatype te maken.
record Bestelling(string Product, int Aantal);
