using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoberNavigationConsole.Util
{
    static class InputUtil
    {
        public static List<Field> FIELDS = new List<Field>
        {
            new Field
            {
                type = new FieldType
                {
                    id=0,
                    type="NUMBER"
                },
                options = new List<char>{'0','9'},
                isBetween = true,
                isContains = false,
                errorMesage = "Please Enter a Number!"
            },
            new Field
            {
                type = new FieldType
                {
                    id=1,
                    type="POLE"
                },
                options = new List<char>{'N','S','E','W'},
                isBetween = false,
                isContains = true,
                errorMesage = "Please Enter a Pole like 'N','S','E','W'!"
            },
            new Field
            {
                type = new FieldType
                {
                    id=2,
                    type="COMMAND"
                },
                options = new List<char>{'L','A','R'},
                isBetween = false,
                isContains = true,
                errorMesage = "Please Enter a text with the next commands  A: Advance, L: Turn Left and R: Turn Right!"
            }
        };


        public static int NumberField(string label, bool opcional)
        {
            return Convert.ToInt32(StringField(label, opcional, 0));
        }

        public static char PoleField(string label, bool opcional)
        {
            
            return StringField(label, opcional, 1)[0];
        }
        public static string CommandField(string label, bool opcional)
        {
            return StringField(label, opcional, 2);
        }

        public static string StringField(string label, bool opcional, int type)
        {
            string text = "";
            Field textfield = FIELDS.Find((f) => f.type.id == type);
            bool valid = false;
            do
            {
                int mistakes = 0;
                try
                {
                    text = field(label, opcional).ToUpper();
                    
                    foreach (char letter in text)
                    {
                        
                        if (textfield.isBetween) {
                            if(letter < textfield.options[0] || letter > textfield.options[1])
                            {
                                mistakes++;
                                throw new Exception();
                            }
                        }
                        if (textfield.isContains)
                        {

                            bool contains = false;
                            foreach (char option in textfield.options)
                            {
                                if (option == letter) {
                                    contains = true;
                                }
                            }
                            if (!contains)
                            {
                                mistakes++;
                                throw new Exception();
                            }
                            
                        }
                    }
                    if(mistakes == 0)
                    {
                        valid = true;
                    }
                }
                catch (Exception Ex)
                {
                    valid = false;
                    Console.WriteLine(textfield.errorMesage);
                }
            } while (!valid);
            return text;
        }

        private static string field(string label, bool opcional)
        {

            string text = null;
            do
            {
                try{ 
                    Console.WriteLine(label);
                    text = Console.ReadLine();
                }catch (Exception ex)
                {
                    text = null;
                }
            } while (text == null || opcional);
            return text;

        }
        
    }
    
    public class Field
    {
        public FieldType type { get; set; }
        public List<char> options { get; set; }
        public bool isBetween { get; set; }
        public bool isContains { get; set; }
        public string errorMesage { get; set; }

    }
    public class FieldType
    {
        public int id { get; set; }
        public string type { get; set; }
    }
    
}

