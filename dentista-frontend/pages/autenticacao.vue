<template>
  <v-card
    :loading="loading"
    class="mx-auto my-12"
    max-width="374"
    elevation="5"
  >
    <template slot="progress">
      <v-progress-linear color="deep-purple" height="10" indeterminate />
    </template>
    <Login v-if="isLogin" />
    <Cadastro v-else />

    <v-card-actions>
      <v-btn text color="teal accent-4" @click="isLogin = !isLogin">
        {{ isLogin ? 'cadastrar' : 'login' }}
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
export default {
  layout: 'empty',
  data () {
    return {
      isLogin: true,
      loading: false
    }
  }
}
</script>
