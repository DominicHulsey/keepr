<template>
  <div class="home bg-light container-fluid">
    <make-vault></make-vault>
    <h1>Welcome to Keepr™</h1>
    <keep-form></keep-form>
    <div class="row">
      <div :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: 'col-10', lg: 'col-10'})">
        <div class="row justify-content-center mt-4">
          <keep-template v-for="keep in keeps" :keep="keep"></keep-template>
        </div>
      </div>
      <vault-home v-if="$mq == 'md' || $mq == 'lg'"></vault-home>
      <!-- add vaults here -->
    </div>
  </div>
</template>

<script>
  import KeepTemplate from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/keepTemplate.vue";
  import KeepForm from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/keepForm.vue";
  import MakeVault from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/makeVault.vue";
  import VaultHome from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/vaultHome.vue";
  import { Drag, Drop } from "vue-drag-drop";
  export default {
    name: "home",
    mounted() {
      this.$store.dispatch("getKeeps");
      this.$store.dispatch("getVaults");
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      else {
        this.$store.dispatch("getVaultKeeps", this.$store.state.user.id);
      }
    },
    data() {
      return {};
    },
    computed: {
      keeps() {
        return this.$store.state.keeps;
      }
    },
    components: {
      KeepForm,
      KeepTemplate,
      MakeVault,
      VaultHome,
      Drag,
      Drop
    },
    methods: {
      addToVault(keep) {
        console.log(keep);
      }
    }
  };
</script>

<style scoped>
</style>