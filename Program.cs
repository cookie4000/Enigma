public class Program {
    
    public static void Main(){

    string message  = "UKD HCY GHOQYN QJRM WSQIM VFF PFARSN PYUM";
    EnigmaTypeMachine machine = setupMachine();
    string translatedMessage = machine.cipher(message);
    Console.WriteLine("Translated Message: " + translatedMessage);
    
    }
    private static EnigmaTypeMachine setupMachine() { 

        // This method sets up the machine with hard coded values on each wheel 

        // Plugboard
        char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        char[] plugVals = "QKCDEFGHPJBLMNOIARSZUVWXYT".ToCharArray();
        Wheel plugboard = new Wheel(alpha,plugVals);

        // Fast Wheel
        char[] fastKeys = "HUDKRQWSLEZVYXMTNIBPFGCOJA".ToCharArray();
        char[] fastVals = "CJOGAVDRZSKIQXTHWYLUBEFPMN".ToCharArray();
        Wheel fast = new Wheel(fastKeys,fastVals);
        
        // Medium Wheel
        char[] medKeys = "YGSWDCOHLTKZRUNFJIQXPMABVE".ToCharArray();
        char[] medVals = "GSZVAHDQPWBKORNJMLTCEXUIFY".ToCharArray();
        Wheel med = new Wheel(medKeys,medVals);

        // Slow Wheel
        char[] slowKeys = "TRLYSPFNHQUGIXODACMJVZWEKB".ToCharArray();
        char[] slowVals = "QIBVDMLFWYNSRKAOPEXZUJCTHG".ToCharArray();
        Wheel slow = new Wheel(slowKeys,slowVals);

        // Reflector
        char[] refKeys = "EJMZALYXVBWFCRQUONTSPIKHGD".ToCharArray();
        char[] refVals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        Wheel reflect = new Wheel(refKeys,refVals);

        return new EnigmaTypeMachine(plugboard,fast,med,slow,reflect);
    }


}


    
