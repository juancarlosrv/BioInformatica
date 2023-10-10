<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Menu;

class MenuController extends Controller
{
    public function index()
    {
        $menus = Menu::all();
        return view('menus.index', compact('menus'));
    }

 

    public function create()
    {
        return view('menus.create');
    }

 

    public function store(Request $request)
    {
        // Validar y almacenar el nuevo menú
        $menu = new Menu($request->all());
        $menu->save();

 

        return redirect()->route('menus.index')->with('success', 'Menú creado correctamente.');
    }

 

    public function show(Menu $menu)
    {
        return view('menus.show', compact('menu'));
    }

    
 

    public function edit(Menu $menu)
    {
        return view('menus.edit', compact('menu'));
    }

 

    public function update(Request $request, Menu $menu)
    {
        // Validar y actualizar el menú
        $menu->update($request->all());

 

        return redirect()->route('menus.index')->with('success', 'Menú actualizado correctamente.');
    }

 

    public function destroy(Menu $menu)
    {
        // Eliminar el menú
        $menu->delete();

 

        return redirect()->route('menus.index')->with('success', 'Menú eliminado correctamente.');
    }
}
