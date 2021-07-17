<template>
  <div>
    <v-card-title class="text-h4 text--primary">
      Cadastro
    </v-card-title>

    <v-card-text>
      <v-alert v-if="erroMensagem" dense text type="error">
        {{ mensagem }}
      </v-alert>
      <v-text-field v-model="email" label="Usuário" />
      <v-text-field v-model="password" type="password" label="Senha" />
      <v-text-field
        v-model="senhaConfirmada"
        type="password"
        label="Confirmar Senha"
      />
      <v-btn block color="primary" @click="cadastrar()">
        Cadastrar
      </v-btn>
    </v-card-text>
  </div>
</template>
<script>
export default {
  data () {
    return {
      email: '',
      password: '',
      senhaConfirmada: '',
      mensagem: '',
      erroMensagem: false
    }
  },
  watch: {
    senhaConfirmada (senha) {
      if (senha.length < 8) {
        return
      }

      this.mensagem = ''
      this.erroMensagem = false

      if (senha !== this.password) {
        this.mensagem = 'As senhas não coincidem'
        this.erroMensagem = true
      }
    }
  },
  methods: {
    async cadastrar () {
      try {
        const cadastrar = await this.$axios.$post('/Autenticacao/cadastrar', {
          email: this.email,
          password: this.password
        })

        // eslint-disable-next-line no-console
        console.log(cadastrar)
      } catch (error) {
        const { Mensagem } = error.response.data
        // eslint-disable-next-line no-console
        this.mensagem = Mensagem
        this.erroMensagem = true
        // eslint-disable-next-line no-console
      }
    }
  }
}
</script>
