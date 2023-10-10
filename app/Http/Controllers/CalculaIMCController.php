<?php

 

namespace App\Http\Controllers;

 

use Illuminate\Http\Request;

use App\Models\CalculaIMC;
use Ramsey\Uuid\Type\Integer;


 

class CalculaIMCController extends Controller

{

    public function store(Request $request)

    {

        $imc = new CalculaIMC();

 

        $imc->edad = request()->edad;

        $imc->altura = request()->altura;

        $imc->peso = request()->peso;

        $imc->sexo = request()->sexo;

        $imc->imc = round((float)request()->peso / (((float)request()->altura / 100) * ((float)request()->altura / 100)), 2);

 

        $imc->save();

 

        $salida = $this->calculaIMC($imc->imc);

 

        // Generar un menú de dieta aleatorio según el resultado del IMC

        $menuDieta = $this->generarMenuDieta($salida);

 

        return view('menu_dieta')->with('menuDieta', $menuDieta);

    }

 

    public function calculaIMC(float $imc)

    {

        if ($imc < 18.5) {

            $salida = "delgadez o bajo peso";

        } elseif ($imc >= 18.5 && $imc <= 24.9) {

            $salida = "normal o de peso saludable";

        } elseif ($imc >= 25.0 && $imc <= 29.9) {

            $salida = "sobrepeso";

        } elseif ($imc > 30.0) {

            $salida = "obesidad";

        }

 

        return $salida;

    }

    
    public function generarMenuDieta(string $salida)
{
    $menusSemanales = [
        "delgadez o bajo peso" => [
            [
                "titulo" => "Menú 1",
                "desayuno" => [
                    "nombre" => "Opciones de desayuno nutritivo",
                    "foto" => asset('images/lenteja.jpg'),
                    "ingredientes" => [
                        "Ingrediente 1",
                        "Ingrediente 2",
                        "Ingrediente 3",
                    ],
                    "informe_nutricional" => [
                        "Calorías: 300",
                        "Proteínas: 15g",
                        "Grasas: 8g",
                        "Carbohidratos: 45g",
                    ],
                ],
                "almuerzo" => [
                    "nombre" => "Alimentos ricos en proteínas y carbohidratos",
                    "foto" => asset('images/lenteja.jpg'),
                    "ingredientes" => [
                        "Ingrediente 1",
                        "Ingrediente 2",
                        "Ingrediente 3",
                    ],
                    "informe_nutricional" => [
                        "Calorías: 400",
                        "Proteínas: 20g",
                        "Grasas: 10g",
                        "Carbohidratos: 60g",
                    ],
                ],
                "cena" => [
                    "nombre" => "Comidas balanceadas",
                    "foto" => asset('images/lenteja.jpg'),
                    "ingredientes" => [
                        "Ingrediente 1",
                        "Ingrediente 2",
                        "Ingrediente 3",
                    ],
                    "informe_nutricional" => [
                        "Calorías: 350",
                        "Proteínas: 18g",
                        "Grasas: 9g",
                        "Carbohidratos: 50g",
                    ],
                ],
            ],
            // Define más menús aquí
        ],
        // Define menús para otras categorías de IMC
    ];
    
 

    $menuDieta = [];

 

    // Seleccionar aleatoriamente uno de los menús según la categoría de IMC
    if (array_key_exists($salida, $menusSemanales)) {
        $menuAleatorio = array_rand($menusSemanales[$salida]);
        $menuDieta = $menusSemanales[$salida][$menuAleatorio];
    }

 

    return $menuDieta;
}

}
?>
