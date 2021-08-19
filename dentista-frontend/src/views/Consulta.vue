<template>
  <div>
    <h1 class="font-sans text-3xl text-center py-2">
      Consultas
    </h1>
    <FiltrosConsulta class="mb-5" />
    <TabelaConsulta />
  </div>
</template>

<script>
import TabelaConsulta from "../components/TabelaConsulta.vue";
import FiltrosConsulta from "../components/FiltrosConsulta.vue";
export default {
  components: {
    TabelaConsulta,
    FiltrosConsulta
  }
};
</script>

<style lang="scss" scoped></style>
