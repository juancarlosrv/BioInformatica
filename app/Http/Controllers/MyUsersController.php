<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

use App\Models\MyUser;

class MyUsersController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        
        $myUsers = MyUser::all();

        return view('BioInformatica.login',['myUsers' => $myUsers]);
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        //
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        //
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(string $id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        //
    }

    public function login()
    {
        $myUsersTodos = new MyUser;
       
        $myUser = request()->usuario;
        //$myUser->contra= request()->contra;
        
        $myUsersTodos = MyUser::all();
        $bandera = false;

        //var_dump($myUser);

        
        foreach ($myUsersTodos as  $value) {
            
            //echo 'Keeeeeeey ' . $key . '<br>';
            //echo 'Valueeeeee' . $value;


            if($value->usuario == request()->usuario && $value->contrasenia == request()->contra){
                $salida = "Usuario Correcto";
            }
            else{
                $salida = "Contraseña o usuario mal";
            }
        }


        //print_r("Holaaaaaaaaaaa")

        return $salida;
        //return redirect()->route('BioInformatica')->with('success','Se inserto con exito');
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        //
    }
}
