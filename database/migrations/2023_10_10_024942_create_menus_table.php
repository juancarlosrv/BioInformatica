<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

 

class CreateMenusTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('menus', function (Blueprint $table) {
            $table->id();
            $table->string('titulo');
            $table->string('categoria_imc');
            $table->string('tipo_comida'); // Puede ser 'desayuno', 'almuerzo', o 'cena'
            $table->string('nombre_comida');
            $table->string('foto'); // Almacena la ruta a la imagen
            $table->json('ingredientes'); // Almacena los ingredientes en formato JSON
            $table->json('informe_nutricional'); // Almacena el informe nutricional en formato JSON
            $table->timestamps();
        });
    }

 

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('menus');
    }
}
