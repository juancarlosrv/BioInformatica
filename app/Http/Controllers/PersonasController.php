<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Persona;
use DB;

class PersonasController extends Controller
{
    //index para mostrar los datos
    //store para guardar una persona
    //update para actualizar
    //destroy para eliminar una persona
    //edit patra mostrar el formulario de edicion


    public function store(Request $request){

        /*$request->validate([
            'nombres' =>'required'
        ]);*/

        $persona = new Persona;

        
/*
        $persona->ci = '2323';
        $persona->nombres = 'Juank';
        $persona->apellidoPat = 'dsds';
        $persona->apellidoMat = 'dsds';
        $persona->fechaNac = '2023-12-12';
        $persona->altura = 52;
        $persona->peso = 58;
*/


        /*
        if(!empty($_POST['ci'])){

        }
        */

        //print_r(request()->ci);


/*
        $persona->ci = $_POST['ci'];
        $persona->nombres = $_POST['nombre'];
        $persona->apellidoPat = $_POST['apellidoPat'];
        $persona->apellidoMat = $_POST['apellidoMat'];
        $persona->fechaNac = $_POST['fechaNac'];
        $persona->altura = $_POST['altura'];
        $persona->peso = $_POST['peso'];
*/
        //var_dump($_POST['ci']);


        $persona->ci = request()->ci;
        $persona->nombres = request()->nombre;
        $persona->apellidoPat = request()->apellidoPat;
        $persona->apellidoMat = request()->apellidoMat;
        $persona->fechaNac = request()->fechaNac;
        $persona->altura = request()->altura;
        $persona->peso = request()->peso;





        //$banderaInsertada = $persona->save();
        $persona->save();
/*
        if($banderaInsertada==true){
            //return "Se inserto con exito";

            return redirect()->route('/BioInformatica')->with('success','Se inserto con exito');

        }
        else{
            return "No se inserto con exito";
        }*/

        //var_dump($request);
        //return "Hola";
        return redirect()->route('BioInformatica')->with('success','Se inserto con exito');
       
    }


    public function index(){
        $personas = Persona::all();
        //$personas = ['Hola','kilñ'];

        return view('BioInformatica.index',['personas' => $personas]);
        //return "Holaaaaaaaa";
    }

    public function show($id){
        $persona = Persona::find($id);
        

        return view('BioInformatica.show',['persona' => $persona]);
        //return "Holaaaaaaaa";
    }

    public function update(Request $request,$id){
        $persona = Persona::find($id);
        
       

        $persona->ci = request()->ci;
        $persona->nombres = request()->nombre;
        $persona->apellidoPat = request()->apellidoPat;
        $persona->apellidoMat = request()->apellidoMat;
        $persona->fechaNac = request()->fechaNac;
        $persona->altura = request()->altura;
        $persona->peso = request()->peso;

        $persona->save();

        return redirect()->route('BioInformatica')->with('success','Se Actualizo con exito');
        //return view('BioInformatica.index',['success' => 'Actualizados']);

        //return "Holaaaaaaaa";
    }

    public function destroy($id){
        $persona = Persona::find($id);
        $persona->delete();

        
        return redirect()->route('BioInformatica')->with('success','Se Elimino con exito');


    }





}
