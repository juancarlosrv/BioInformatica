

@extends('app');

@section('content')


</div>

<h1 style="text-align: center;">
FORMULARIO DE REGISTRO
</h1>


<div class="row">

<div class="col-1">



</div>

<div class="col-8">

<form action="{{ route('BioInformatica') }}" method="post">
@csrf






@if (session('success'))

<h6 class="alert alert-success">{{session('success') }} </h6>

@endif

@error('ci')

<h6 class="alert alert-danger">{{ $message }} </h6>

@enderror

        <div class="form-group">

        <label for="">CI</label>

        <input type="text"

        class="form-control" name="ci" id="ci" aria-describedby="helpId" placeholder="CI" required>

        

    </div>
    <div class="form-group">

        <label for="">Nombre</label>

        <input type="text"

        class="form-control" name="nombre" id="nombre" aria-describedby="helpId" placeholder="Nombre" required>

        

    </div>



    <div class="row">

        <div class="col-6">

            <div class="form-group">

            <label for="">Apellido Paterno</label>

            <input type="text"

                class="form-control" name="apellidoPat" id="apellidoPat" aria-describedby="helpId" placeholder="Apellido Paterno" required>

            

            </div>

        </div>

        <div class="col-6">

        <div class="form-group">

            <label for="">Apellido Materno</label>

            <input type="text"

                class="form-control" name="apellidoMat" id="apellidoMat" aria-describedby="helpId" placeholder="Apellido Materno">

            </div>

        </div>

    </div>

    <div class="row">

        <div class="col-4">

            <div class="form-group">

            <label for="fechaNac">Fecha de Nacimiento:</label>
            <input type="date" class="form-control" id="fechaNac" name="fechaNac" required><br><br>

                

            </div>

        </div>

        <div class="col-4">

        <div class="form-group">

        <label for="altura">Altura (en cm):</label>
        <input type="text"

                class="form-control" name="altura" id="altura" aria-describedby="helpId" placeholder="Altura" required>
            </div>
            </div>
        <div class="col-4">

        <div class="form-group">
                <label for="peso">Peso (en kg):</label>
                <input type="number" class="form-control" id="peso" name="peso" placeholder="Peso" required><br><br>
            </div>
        </div>
    </div>
    <button type="submit" class="btn btn-primary">Registrar Usuario</button>
</form>    

</div>

<div class="col-3">

</div>


<div>

<div class="row">

<div class="col-2">

</div>

<div class="col-8">
<table class="table">


<thead class="table-dark">
<tr>
<th>CI</th>
<th>Nombres</th>
<th>Apellido Paterno</th>
<th>Apellido Materno</th>
<th>Fecha de nacimiento</th>
<th>Altura</th>
<th>Peso</th>
<th>Actualizar</th>
<th>Eliminar</th>
</tr>
    </thead>





@foreach ($personas as $persona)


<tr>
<td>{{ $persona->ci }}</td>
<td>{{ $persona->nombres }}</td>
<td>{{ $persona->apellidoPat }}</td>
<td>{{ $persona->apellidoMat }}</td>
<td>{{ $persona->fechaNac }}</td>
<td>{{ $persona->altura }}</td>
<td>{{ $persona->peso }}</td>
<td><a href="{{ route('personas-edit' , ['id'=> $persona->id]) }}" style="text-decoration: none;"> <button class="btn btn-success btn-sm"> Actualizar</button> </a></td>
<td>

<form action=" {{ route('personas-destroy',[$persona->id]) }} " method="post">

@method('DELETE')
@csrf

    <button class="btn btn-danger btn-sm">Eliminar</button>

</form>

</td>

</tr>




@endforeach

</table>
</div>

<div class="col-2">

</div>

</div>






</div>







</div>

@endsection

