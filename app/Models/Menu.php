<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Menu extends Model
{
    use HasFactory;



    protected $fillable = [
        'titulo',
        'categoria_imc',
        'tipo_comida',
        'nombre_comida',
        'foto',
        'ingredientes',
        'informe_nutricional',
    ];


    protected $casts = [

        'ingredientes' => 'json', // Convierte la columna 'ingredientes' en un arreglo JSON

        'informe_nutricional' => 'json', // Convierte la columna 'informe_nutricional' en un arreglo JSON

    ];

}
