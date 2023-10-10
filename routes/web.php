<?php

use App\Http\Controllers\CalculaIMCController;
use App\Http\Controllers\PersonasController;
use App\Http\Controllers\MyUsersController;
use App\Models\CalculaIMC;
use Illuminate\Support\Facades\Route;


/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "web" middleware group. Make something great!
|
*/

Route::get('/', function () {
    return view('app');
});



/*
Route::get('/BioInformatica', function () {
    return view('BioInformatica.index');
});
*/

/*
//Route::post('/Personas', [PersonasController::class,'store'])->name('BioInformatica');

Route::get('/BioInformatica', [PersonasController::class,'index'])->name('BioInformatica');

//Route::post('/Personas', 'PersonasController@store')->name('BioInformatica');

Route::post('/BioInformatica', [PersonasController::class,'store'])->name('BioInformatica');


Route::get('/BioInformatica/{id}',[PersonasController::class,'show'])->name('personas-edit');

Route::put('/BioInformatica/{id}',[PersonasController::class,'update'])->name('personas-update');

Route::delete('/BioInformatica/{id}',[PersonasController::class,'destroy'])->name('personas-destroy');


Route::resource('/MyUsers',MyUsersController::class);

*/
//Route::get('/MyUsers',[MyUsersController::class,'login'])->name('MyUsers');

//Route::get('/Calculo', [PersonasController::class,'index'])->name('Calculo');

Route::get('/Calculo', function () {
    return view('Calculo.index');
});

Route::post('/Calculo', [CalculaIMCController::class,'store'])->name('Calculo');