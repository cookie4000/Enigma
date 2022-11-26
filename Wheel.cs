public class Wheel{
    public List<Tuple<char, char>> values { get; set; }
    public long countOfRevolutions{ get; set; }

    public Wheel(char[] keys, char[] values) {
        
        List<Tuple<char, char>> listOfValues = new List<Tuple<char, char>>();

        // Convert the char arrays to the tuples
        for (int i = 0; i < keys.Length; i++) {
            listOfValues.Add(Tuple.Create(keys[i],values[i]));
            
        }
        
        this.values = listOfValues;
        this.countOfRevolutions = 0;

    }

    public void Rotate() {
        
        // put the first item onto the bottom - then remove the first item
        Tuple<char, char> firstItem = this.values[0];
        this.values.Add(firstItem);
        this.values.RemoveAt(0);    
    }


}