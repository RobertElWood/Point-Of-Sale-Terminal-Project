using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal
{
    public class Logo
    {
        public string Beauty { get; set; }


        public Logo()
        {
            //Beautify
            string logo = @"
                                 _____      _               ____                                                    
                                |  __ \    | |             |  _ \                                               
                                | |__) |___| |_ _ __ ___   | |_) | ___  _   _ ___                               
                                |  _  // _ \ __| '__/ _ \  |  _ < / _ \| | | / __|                              
                                | | \ \  __/ |_| | | (_) | | |_) | (_) | |_| \__ \                              
                                |_|  \_\___|\__|_|  \___/  |____/ \___/ \__, |___/                              
                                  _____                         _____ _  __/ |                              
                                 / ____|                       / ____| ||___/                               
                                | |  __  __ _ _ __ ___   ___  | (___ | |_ ___  _ __ ___                     
                                | | |_ |/ _` | '_ ` _ \ / _ \  \___ \| __/ _ \| '__/ _ \                    
                                | |__| | (_| | | | | | |  __/  ____) | || (_) | | |  __/                    
                                 \_____|\__,_|_| |_| |_|\___| |_____/ \__\___/|_|  \___|                    ";
            //Beautify2
            string logo2 = @"

                		     ,---.U                      ________________
                		 .==\""/==. 			|   |,""    `.|   | 
                		((+) .  .:)	                |   /  SONY  \   |
                		|`.-(o)-.'|			|O _\   />   /_  |    ___ _
                		\/  \_/  \/			|_(_)'.____.'(_)_|  ("")__("")
                					        [___|[=]__[=]|___]  //    \\
                							\         /``
                							 `-.___.-'   ";
            Console.WriteLine(logo + logo2);
        }

    }
}
