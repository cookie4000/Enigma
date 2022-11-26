using System.Text;

public class EnigmaTypeMachine {

    private Wheel plugboard {get; set;}
    private Wheel fastWheel {get;set;}
    private Wheel mediumWheel {get;set;}
    private Wheel slowWheel {get;set;}
    private Wheel reflector {get;set;}

    public const int LETTERS_PER_WHEEL = 26;

    public EnigmaTypeMachine(Wheel plug,Wheel fast,Wheel medium,Wheel slow, Wheel reflect) {
        this.plugboard = plug;
        this.fastWheel = fast;
        this.mediumWheel = medium;
        this.slowWheel = slow;
        this.reflector = reflect;
    }

public string cipher(string message) { 
    
    char[] chars  = message.ToUpper().ToCharArray();
    StringBuilder sb = new StringBuilder();

    // Loop through each character in the message
    for (int i = 0; i < chars.Length; i++) {

        char letterToTranslate = chars[i];
        if (letterToTranslate==' ') {
            sb.Append(' ');
        }
        else {
            // Write Translated Character to string builder
            sb.Append(translateCharacter(letterToTranslate));

            // Rotate the wheels if required
            rotateWheels();
        }

    }
    
    return sb.ToString();
}

private void rotateWheels() {

    // Fast wheel - Rotates per character 
    fastWheel.Rotate();
    fastWheel.countOfRevolutions++;
    Console.WriteLine("Rotating Fast Wheel");

    // Medium Wheel - Rotates one point per full fast wheel rotation
    if (this.fastWheel.countOfRevolutions % LETTERS_PER_WHEEL == 0 ) {
        mediumWheel.Rotate();
        mediumWheel.countOfRevolutions++;
        Console.WriteLine("Rotating Medium Wheel");
        
    }
    
    // Slow Wheel - Rotates one point per full medium wheel rotation
     if (this.mediumWheel.countOfRevolutions>0 && this.mediumWheel.countOfRevolutions % LETTERS_PER_WHEEL == 0 ) {
        slowWheel.Rotate();
        slowWheel.countOfRevolutions++;
        Console.WriteLine("Rotating Slow Wheel");
    }
}
private char translateCharacter(char characterToTranslate) {

    int reflectorPos = getReflectorValue(characterToTranslate);
    char translationVal = getTranslationFromReflector(reflectorPos);

    return translationVal;
}
private char getTranslationFromReflector(int reflectorPosition) {

    // Slow wheel 
    int slowWheelKeyPosition = getReturningposition(reflectorPosition,this.slowWheel);

    // Medium wheel
    int medWheelKeyPosition = getReturningposition(slowWheelKeyPosition,this.mediumWheel);

    // Fast wheel
    int fastWheelKeyPosition = getReturningposition(medWheelKeyPosition,this.fastWheel);

    // Plugboard
    int plugboardKeyPosition  = getReturningposition(fastWheelKeyPosition,this.plugboard);

    return getKeyFromPosition(plugboardKeyPosition,this.plugboard);
}
private int getReflectorValue (char characterToTranslate) {

    // Plugboard
    int plugboardPosition = getLetterPositionValues(characterToTranslate,this.plugboard);

    // Fast Wheel
    int fastWheelPosition = getForwardPosition(plugboardPosition,this.fastWheel);   

    // Medium Wheel  
    int medWheelPosition = getForwardPosition(fastWheelPosition,this.mediumWheel);   
    
    // Slow Wheel
    int slowWheelPosition = getForwardPosition(medWheelPosition,this.slowWheel);   

    // Reflector
    int reflectPosition = getForwardPosition(slowWheelPosition,this.reflector);

    return reflectPosition;
}

private int getReturningposition(int position,Wheel wheel) {
    
    char value = getValueFromPosition(position,wheel);
    int keyPosition = getLetterPositionKeys(value,wheel);

    return keyPosition;
}
private int getForwardPosition(int position,Wheel wheel) {
    char key = getKeyFromPosition(position,wheel);
    int forwardposition = getLetterPositionValues(key,wheel);

    return forwardposition;
}
private char getKeyFromPosition(int position,Wheel wheel) { 
    // Going to the reflector
    return wheel.values[position].Item1;
}

private char getValueFromPosition(int position,Wheel wheel) { 
    // Coming back from the reflector
    return wheel.values[position].Item2;
}

private int getLetterPositionValues(char value,Wheel wheel) { 
    
    // Inbound (Validate Item 2 in the Tuple)
    int count=0;

    foreach (Tuple<char, char> t in wheel.values) {
        if (wheel.values[count].Item2 == value) {
            break;
        }
        count++;    
    }
    return count;
}

private int getLetterPositionKeys(char value,Wheel wheel) { 
    
    // Outbound (validate Item1 in Tuple)
    int count=0;

    foreach (Tuple<char, char> t in wheel.values) {
        if (wheel.values[count].Item1 == value) {
            break;
        }
        count++;    
    }
    return count;
}

}
