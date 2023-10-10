<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\CalculaIMC;
use Ramsey\Uuid\Type\Integer;

class CalculaIMCController extends Controller
{
   //index para mostrar los datos
    //store para guardar una persona
    //update para actualizar
    //destroy para eliminar una persona
    //edit patra mostrar el formulario de edicion


    public function store(Request $request){

       

        $imc = new CalculaIMC();

        

        $imc->edad = request()->edad;
        $imc->altura = request()->altura;
        $imc->peso = request()->peso;
        $imc->sexo = request()->sexo;
        $imc->imc = round((float)request()->peso/(((float)request()->altura/100)*((float)request()->altura/100)),2);

        
        


        $imc->save();



        $salida = $this->calculaIMC($imc->imc);

        echo $salida . "";

        return redirect()->route('Calculo')->with('success','Tu IMC es: ' . $imc->imc . " Usted tiene : " . $salida);
       
    }

    public function calculaIMC(float $imc){

        if($imc<18.5 ){
            $salida = "delgadez o bajo peso";

        }
        else if($imc>=18.5 && $imc<=24.9){
            $salida = "normal o de peso saludable";
        }
        else if($imc>=25.0 && $imc<=29.9){
            $salida = "sobrepeso";
        }
        else if($imc>30.0){
            $salida = "“obesidad”";
        }

        return $salida;

    }
    
}
