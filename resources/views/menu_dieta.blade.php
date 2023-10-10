@extends('app')

 

@section('content')

 

<div class="container mt-5">
<!-- ... Tu contenido anterior ... -->

<h2>{{ $menuDieta['titulo'] }}</h2>

 

<div class="row">

    <div class="col-md-4">

        <h4>Desayuno:</h4>

        <p>{{ $menuDieta['desayuno']['nombre'] }}</p>

        <img src="{{ $menuDieta['desayuno']['foto'] }}" alt="Desayuno" class="img-fluid">

        <h5>Ingredientes:</h5>

        <ul>

            @foreach ($menuDieta['desayuno']['ingredientes'] as $ingrediente)

                <li>{{ $ingrediente }}</li>

            @endforeach

        </ul>

        <h5>Informe Nutricional:</h5>

        <ul>

            @foreach ($menuDieta['desayuno']['informe_nutricional'] as $dato)

                <li>{{ $dato }}</li>

            @endforeach

        </ul>

    </div>




    <div class="col-md-4">

<h4>Almuerzo:</h4>

<p>{{ $menuDieta['almuerzo']['nombre'] }}</p>

<img src="{{ $menuDieta['almuerzo']['foto'] }}" alt="almuerzo" class="img-fluid">

<h5>Ingredientes:</h5>

<ul>

    @foreach ($menuDieta['almuerzo']['ingredientes'] as $ingrediente)

        <li>{{ $ingrediente }}</li>

    @endforeach

</ul>

<h5>Informe Nutricional:</h5>

<ul>

    @foreach ($menuDieta['almuerzo']['informe_nutricional'] as $dato)

        <li>{{ $dato }}</li>

    @endforeach

</ul>

</div>







<div class="col-md-4">

<h4>Cena:</h4>

<p>{{ $menuDieta['cena']['nombre'] }}</p>

<img src="{{ $menuDieta['cena']['foto'] }}" alt="cena" class="img-fluid">

<h5>Ingredientes:</h5>

<ul>

    @foreach ($menuDieta['cena']['ingredientes'] as $ingrediente)

        <li>{{ $ingrediente }}</li>

    @endforeach

</ul>

<h5>Informe Nutricional:</h5>

<ul>

    @foreach ($menuDieta['cena']['informe_nutricional'] as $dato)

        <li>{{ $dato }}</li>

    @endforeach

</ul>

</div>



    <!-- Repite lo mismo para cena y cena -->

</div>





    <!-- ... Tu contenido posterior ... -->
</div>

 

@endsection