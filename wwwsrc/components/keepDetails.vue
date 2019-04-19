<template>
  <div class="indivKeep">
    <div class="modal fade" :id="'Modal' + keep.id" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog" role="document" style="max-width:70vw;">
        <div class="modal-content" style="margin-top:10%;">
          <div class="modal-body row m-0 p-0">
            <div class="col-6">
              <div style="position:absolute; top:25%;">
                <h5 class="mt-3 text-left" style="font-weight:bold;font-size:3rem">{{keep.name}}</h5>
                <hr>
                <h5 class="text-left p-0">{{keep.description}}</h5>
              </div>
              <hr>
              <div class="p-4" style="position:absolute;bottom:0%; width:100%;">
                <div class="row justify-content-around">
                  <p class="m-0"> Views: <span style="font-weight:bolder">{{keep.views}}</span></p>
                  <p class="m-0"> Keeps: <span style="font-weight:bolder">{{keep.keeps}}</span></p>
                  <p class="m-0"> Shares: <span style="font-weight:bolder">{{keep.shares}}</span></p>
                </div>
                <hr>
                <div class="row justify-content-around mb-3" style="vertical-align: bottom;">
                  <div class="backV p-3 px-4 text-white cursor" @click="keep.views+= 1"><i class="fas fa-eye"></i>
                  </div>
                  <div class="backK p-3 px-4 text-white cursor" @click="keep.keeps+= 1"><i class="fas fa-praying-hands"
                      @click="keep.keeps+= 1"></i>
                  </div>
                  <div class="backS p-3 px-4 text-white cursor" @click="keep.shares+= 1"><i class="fas fa-share"></i>
                  </div>
                </div>
                <div class=" modal-footer">
                  <button type="button" class="btn btnBGB text-white" data-dismiss="modal">Close</button>
                  <div class="dropdown">
                    <button class="btn btnBG text-white dropdown-toggle" type="button" id="dropdownMenuButton"
                      data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                      Add to Vault
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                      <a v-for="vault in vaults" @click="addToVault(vault)" class="dropdown-item"
                        href="#">{{vault.name}}</a>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="col-6 p-0 align-items-center">
              <img :src="keep.img " style="min-width:100%; height:auto; max-height:80vh;" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'indivKeep',
    props: ['keep'],
    data() {
      return {}
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      addCount(keep, toAdd) {
        let payload = {
          keepData: keep,
          choice: toAdd
        }
        this.$store.dispatch("addCount", payload)
      },
      addToVault(vault) {
        let payload = {
          vaultId: vault.id,
          userId: this.$store.state.user.id,
          keepId: this.keep.id
        }
        this.$store.dispatch("addToVault", payload)
        this.addCount(this.keep, "keeps")
      },
    },
    components: {}
  }
</script>


<style scoped>
  .backV {
    background: #9854bb;
  }

  .cursor {
    cursor: pointer;
  }

  .backK {
    background: #fc0095;
  }

  .modal-content {
    border-radius: 2px;
  }

  .backS {
    background: black;
  }

  .btnBG {
    background-color: #9854bb;
    border-radius: 0;
  }

  .btnBGB {
    background-color: black;
    border-radius: 0;
  }
</style>