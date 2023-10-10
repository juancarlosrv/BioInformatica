<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('calcula_i_m_c_s', function (Blueprint $table) {
            $table->id();
            $table->integer('edad');
            $table->integer('altura');
            $table->float('peso');
            $table->char('sexo');
            $table ->float('imc');
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('calcula_i_m_c_s');
    }
};
